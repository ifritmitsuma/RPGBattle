using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCommand : Command
{
    public override string name {
        get {
            return "Focus";
        }
    }

    public override bool isFinal { get {
        return true;
    }}
    
    public override void affect()
    {
        source.addModifier(Stats.MAGIC, 25);
    }
}
