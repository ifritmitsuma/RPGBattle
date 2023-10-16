using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TimeBasedATB : ATBManager
{

    Dictionary<Character, float> characters = new Dictionary<Character, float>();

    Queue<Command> commandQueue = new Queue<Command>();

    //Command activeCommand = null;
    private bool busy = false;

    private MonoBehaviour mb;

    private GUIManager guiManager;

    private AnimationManager animationManager;

    public TimeBasedATB(MonoBehaviour mb, GUIManager guiManager, AnimationManager animationManager) {
        this.mb = mb;
        this.guiManager = guiManager;
        this.animationManager = animationManager;
    }

    public void push(Command command) {

        command.source.busy = true;
        commandQueue.Enqueue(command);

    }

    public void update() {

        if(guiManager.debug) {
            guiManager.updateATBQueue(commandQueue);
        } 

        if(!busy && commandQueue.Count > 0) {
            this.busy = true;
            applyCommand();
        }

    }

    private async void applyCommand() {
        Command activeCommand = commandQueue.Dequeue();
        guiManager.showMessage(activeCommand.name, 2f);
        if(activeCommand is Skill) {
            animationManager.animate("Cast", activeCommand.source.gameObject.transform.position);
        }
        activeCommand.source.gameObject.GetComponent<CharacterController>().castAnimation();
        await Task.Delay(2000);
        activeCommand.affect();
        clear(activeCommand.source);
        activeCommand.source.busy = false;
        this.busy = false;
    }

    public int getATBValue(Character character) {
        addCharacter(character);
        return (int) characters[character];
    }

    public bool tick(Character character) {

        if(character.busy) {
            return false;
        }

        addCharacter(character);
        if(characters[character] < 255.0f) {
            characters[character] += 0.5f;
        }
        return characters[character] == 255.0f;
    }

    public void clear(Character character) {
        characters[character] = 0;
    }

    private void addCharacter(Character character) {
        if(!characters.ContainsKey(character)) {
            // Add Speed Influence
            characters.Add(character, (int) (Random.Range(0, 2.55f) * 100));
        }
    }
    
}
