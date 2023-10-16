using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    private List<Player> players = new List<Player>();

    private List<Foe> foes = new List<Foe>();

    public delegate void Behaviour(Character c);
    private Dictionary<Character, Behaviour> behavioursNextTurn = new Dictionary<Character, Behaviour>();

    private static BattleManager instance;

    private ATBManager atbManager;

    public GUIManager guiManager;

    public AudioManager audioManager;

    public AnimationManager animationManager;

    public List<Item> itemList = new List<Item> {
        new Potion(5),
        new HiPotion(2)
    };

    public List<Command> commandList;

    private int xp;

    private int ap;

    private int gil;

    private List<Item> drops = new List<Item>();

    private bool started = false;

    private bool ended = false;

    void Awake() {
        BattleManager.instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        this.commandList = new List<Command>{
            new AttackCommand(),
            new DefendCommand(),
            new ChangeCommand(),
            new ItemCommand()
        };

        // Later remove when camera animations are implemented
        this.started = true;

        foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
            players.Add(player.GetComponent<PlayerController>().GetPlayer());
        }

        foreach(GameObject foe in GameObject.FindGameObjectsWithTag("Foe")) {
            foes.Add(foe.GetComponent<FoeController>().GetFoe());
        }

        if(this.started) {
            audioManager.playMusic("Battle1");
            atbManager = new TimeBasedATB(this, guiManager, animationManager);
            guiManager.atbManager = atbManager;
            guiManager.showPartyInfo(players);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(!this.started) {
            return;
        }

        if(this.ended) {
            return;
        }

        // Check if GameOver or Battle won
        if(this.isGameOver() || this.isBattleWon()) {
            this.ended = true;
            return;
        }

        this.advanceATB();
        atbManager.update();

    }

    public static BattleManager get() {
        return BattleManager.instance;
    }

    bool isGameOver() {
        
        bool playerAlive = false;
        
        foreach(Character player in players) {
            playerAlive = !player.isDead();
            if(playerAlive) {
                break;
            }
        }

        if(!playerAlive) {
            this.GameOver();
            return true;
        }

        return false;
        
    }

    bool isBattleWon() {
        
        List<Foe> foesLocal = new List<Foe>((List<Foe>) foes);

        foreach(Foe foe in foesLocal) {
            if(foe.isDead()) {
                xp += foe.getXP();
                ap += foe.getAP();
                gil += foe.getGil();
                drops.AddRange(foe.getDrops());
                foes.Remove(foe);
            }
        }
        
        if(foes.Count == 0) {
            BattleWon();
        }

        return foes.Count == 0;

    }

    void GameOver() {
        guiManager.hide();
        guiManager.showGameOverSplash();
        audioManager.playMusic("GameOver");
    }

    void BattleWon() {
        guiManager.hide();
        //guiManager.showGameOverSplash();
        audioManager.playMusic("Fanfare");
    }

    void advanceATB() {

        List<Character> all = new List<Character>(players);
        all.AddRange(foes);

        foreach(Character character in all) {
            if(character.isDead()) {
                if(atbManager.getATBValue(character) != 0) {
                    atbManager.clear(character);
                }
                continue;
            } else if(atbManager.tick(character)) {
                if(behavioursNextTurn.ContainsKey(character)) {
                    behavioursNextTurn[character](character);
                    behavioursNextTurn.Remove(character);
                }
                if(character is Player && !guiManager.isMenuShown()) {
                    Player player = (Player) character;
                    guiManager.showMenu(player);
                    List<Command> commands = new List<Command>();
                    foreach(Command command in commandList) {
                        commands.Add(command.clone());
                    }
                    commands.AddRange(player.GetSkills());
                    guiManager.setMenuCommands(player, commands);
                } else if(character is Foe) {
                    atbManager.push(((Foe) character).executeAI(players.FindAll(p => !p.isDead()), foes));
                }
            }
        }

    }

    public List<Player> GetPlayers() {
        return players;
    }

    public List<Foe> GetFoes() {
        return foes;
    }

    public void getTargets(Character character) {
        List<Character> targets = new List<Character>(foes);
        guiManager.selectTargets(character, targets);
    }

    public void getTargets(Character character, bool isHeal) {
        List<Character> targets = new List<Character>(foes);
        if(isHeal) {
            targets = new List<Character>(players);
        }
        guiManager.selectTargets(character, targets);
    }

    public void addBehaviourNextTurn(Character source, Behaviour behaviour) {
        behavioursNextTurn.Add(source, behaviour);
    }

    public List<Item> getItems() {
        return this.itemList;
    }

    public void useItem(Item item) {
        int index = itemList.FindIndex((i) => i.name == item.name);
        itemList[index].count--;
        if(itemList[index].count == 0) {
            itemList.RemoveAt(index);
        }
    }

    public void getItem(Item item) {
        int index = itemList.FindIndex((i) => i.name == item.name);
        if(index == -1) {
            item.count = 1;
            itemList.Add(item);
        } else {
            itemList[index].count++;
        }
    }

}
