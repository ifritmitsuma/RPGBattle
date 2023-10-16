using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{

    public abstract string name { get; }

    public virtual bool isFinal { get {
        return false;
    }}

    public GUIManager guiManager;

    public BattleManager battleManager;

    public AnimationManager animationManager;

    public Character source;

    public List<Character> targets;

    public virtual List<Command> subMenu { get {
        return null;
    } }

    public Command() {
        this.battleManager = BattleManager.get();
        this.guiManager = GUIManager.get();
        this.animationManager = AnimationManager.get();
    }

    public abstract void affect();

    public Command clone() {
        return (Command) this.MemberwiseClone();
    }

}
