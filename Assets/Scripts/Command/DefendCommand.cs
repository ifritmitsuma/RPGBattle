using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendCommand : Command
{
    public override string name {
        get {
            return "Defend";
        }
    }

    public override bool isFinal { get {
        return true;
    }}

    public override void affect()
    {
        source.addModifier(Stats.DEFENSE, 50);
        battleManager.addBehaviourNextTurn(source, (ch) => {
            ch.clearModifier(Stats.DEFENSE);
        });
    }
}
