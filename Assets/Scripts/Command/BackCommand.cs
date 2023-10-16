using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCommand : Command
{
    public override string name {
        get {
            return "Back";
        }
    }

    public override bool isFinal {
        get {
            return true;
        }
    }

    private Character character;

    private List<Command> commands;

    public BackCommand(Character character, List<Command> commands) {
        this.character = character;
        this.commands = commands;
    }

    public override void affect()
    {
        guiManager.setMenuCommands(character, commands);
    }
}
