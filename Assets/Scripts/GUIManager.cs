using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public GameObject lowerUI;

    public Canvas uiCanvas;

    public GameObject messagePanel;

    private int messageCount = 0;

    public Canvas partyInfoCanvas;

    public Canvas menuCanvas;

    public GameObject charInfoPrefab;

    public GameObject commandButtonPrefab;

    public GameObject damageTextPrefab;

    public static GUIManager instance;

    public ATBManager atbManager;

    public BattleManager battleManager;

    public Command toSelectTargets;

    private Dictionary<Player, GameObject> charInfos = new Dictionary<Player, GameObject>();

    public bool debug = false;

    public Canvas debugCanvas;

    public Text atbQueue;

    private Player characterMenuIsShownFor;

    void Awake()
    {
        GUIManager.instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        debugCanvas.enabled = this.debug;
        foreach(Player player in charInfos.Keys) {
            GameObject charInfo = charInfos[player];
            charInfo.transform.Find("HP").GetComponent<Text>().text = player.hp.ToString();
            charInfo.transform.Find("MP").GetComponent<Text>().text = player.mp.ToString();
            charInfo.transform.Find("ATB").GetComponent<Slider>().value = atbManager.getATBValue(player);
        }

        if(characterMenuIsShownFor != null && characterMenuIsShownFor.isDead()) {
            this.hideMenu();
        }
    }

    public static GUIManager get() {
        return GUIManager.instance;
    }

    public void hide() {
        lowerUI.SetActive(false);
    }

    public void show() {
        lowerUI.SetActive(true);
    }

    public void showMenu(Character character) {
        menuCanvas.gameObject.SetActive(true);
    }

    public void hideMenu() {
        menuCanvas.gameObject.SetActive(false);
        characterMenuIsShownFor = null;
    }

    public bool isMenuShown() {
        return menuCanvas.gameObject.activeSelf;
    }

    public void showGameOverSplash() {

    }

    public void showPartyInfo(List<Player> players) {

        GameObject topBar = partyInfoCanvas.transform.Find("TopBar").gameObject;
        float nameSpace = 50 * Screen.height / 900;

        for(int i = 0; i < players.Count; ++i) {
            Player player = players[i];
            GameObject charInfo = Instantiate(charInfoPrefab, partyInfoCanvas.transform);
            charInfo.transform.Find("Name").GetComponent<Text>().text = player.charName;
            charInfos[player] = charInfo;
            charInfo.transform.Translate(new Vector3(0, nameSpace * (players.Count - i - 1), 0));
        }

        topBar.transform.Translate(new Vector3(0, nameSpace * players.Count, 0));

    }

    public void setMenuCommands(Character character, List<Command> commands) {
        clearMenuCommands();
        for(int i = 0; i < commands.Count; ++i) {
            GameObject commandObject =  Instantiate(commandButtonPrefab, menuCanvas.transform.Find("Panel/Slot" + (i + 1)));
            Command command = commands[i];
            command.source = character;
            addManager(command);
            command.battleManager = battleManager;
            if(command is Skill) {
                Skill skill = (Skill) command;
                Transform skillT = commandObject.transform.Find("Button/SkillName");
                Transform mpCost = commandObject.transform.Find("Button/MPCost");
                skillT.GetComponent<Text>().text = command.name;
                skillT.gameObject.SetActive(true);
                mpCost.GetComponent<Text>().text = skill.mpCost.ToString();
                mpCost.gameObject.SetActive(true);
                if(!skill.canUserUseSpell()) {
                    skillT.GetComponent<Text>().color = Color.gray;
                    mpCost.GetComponent<Text>().color = Color.gray;
                }
            } else if(command is Item) {
                Item item = (Item) command;
                Transform skillT = commandObject.transform.Find("Button/SkillName");
                Transform mpCost = commandObject.transform.Find("Button/MPCost");
                skillT.GetComponent<Text>().text = command.name;
                skillT.gameObject.SetActive(true);
                mpCost.GetComponent<Text>().text = item.count.ToString();
                mpCost.gameObject.SetActive(true);
            } else {
                Transform text = commandObject.transform.Find("Button/CommandText");
                text.GetComponent<Text>().text = command.name;
                text.gameObject.SetActive(true);
            }

            UnityEngine.Events.UnityAction openSubMenu = delegate() { 
                List<Command> subCommands = new List<Command>(command.subMenu);
                subCommands.Add(new BackCommand(character, commands));
                setMenuCommands(character, subCommands);
            };
            UnityEngine.Events.UnityAction getTargets = delegate() { 
                toSelectTargets = command;
                if(command is Skill) {
                    battleManager.getTargets(character, ((Skill) command).isHeal());
                } else if(command is Item) {
                    battleManager.getTargets(character, ((Item) command).isHeal());
                } else {
                    battleManager.getTargets(character);
                }
            };
            UnityEngine.Events.UnityAction affect = delegate() {
                atbManager.push(command);
                this.hideMenu();
            };

            if(command.subMenu != null) {
                commandObject.transform.Find("Button").GetComponent<Button>().onClick.AddListener(openSubMenu);
            } else if(!(command is Skill) || ((Skill) command).canUserUseSpell()){
                if(!command.isFinal) {
                    commandObject.transform.Find("Button").GetComponent<Button>().onClick.AddListener(getTargets);
                } else { 
                    commandObject.transform.Find("Button").GetComponent<Button>().onClick.AddListener(affect);
                }
            }

            characterMenuIsShownFor = (Player) character;
        }
    }

    private void clearMenuCommands() {
        for(int i = 0; i < 9; ++i) {
            Transform slot = menuCanvas.transform.Find("Panel/Slot" + (i + 1));
            if(slot.childCount > 0) {
                GameObject.Destroy(slot.GetChild(0).gameObject);
            }
        }
    }

    public void selectTargets(Character character, List<Character> targets) {
        clearMenuCommands();
        for(int i = 0; i < targets.Count; ++i) {
            GameObject targetObject =  Instantiate(commandButtonPrefab, menuCanvas.transform.Find("Panel/Slot" + (i + 1)));
            Character target = targets[i];
            targetObject.transform.Find("Button/CommandText").GetComponent<Text>().text = target.charName;
            targetObject.transform.Find("Button/CommandText").gameObject.SetActive(true);
            targetObject.transform.Find("Button").GetComponent<Button>().onClick.AddListener(delegate() {
                toSelectTargets.targets = new List<Character>{target};
                atbManager.push(toSelectTargets);
                this.hideMenu();
            });
        }
    }

    public void showDamage(Character target, string text, bool isHeal) {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.gameObject.transform.position);
        GameObject damageText = Instantiate(damageTextPrefab, screenPos, Quaternion.identity, uiCanvas.transform);
        damageText.GetComponent<Text>().text = text;
        if(isHeal) {
            damageText.GetComponent<Text>().color = Color.green;
        }
        StartCoroutine(clearDamage(damageText));
    }

    public void showDamage(Character target, int damage, bool isHeal) {
        showDamage(target, damage.ToString(), isHeal);
    }

    private IEnumerator<WaitForSeconds> clearDamage(GameObject damageObject) {

        yield return new WaitForSeconds(1);

        GameObject.Destroy(damageObject);

    }

    public void showMessage(string text, float time) {

        messagePanel.SetActive(true);
        messagePanel.transform.Find("Text").GetComponent<Text>().text = text;
        StartCoroutine(clearMessage(time));

    }

    private IEnumerator<WaitForSeconds> clearMessage(float time) {

        messageCount++;

        yield return new WaitForSeconds(time);

        messageCount--;
        if(messageCount == 0) {
            messagePanel.SetActive(false);
        }

    }

    public void updateATBQueue(Queue<Command> commandQueue) {

        atbQueue.text = "";

        foreach(Command command in commandQueue) {
            atbQueue.text += command.source.charName + '\n';
        }

    }

    private void addManager(Command command) {
        command.guiManager = this;
    }

}
