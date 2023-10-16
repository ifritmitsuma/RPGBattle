using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteMagicCommand : SubCommand
{
    
    public WhiteMagicCommand(List<Skill> magic) {
        this.list = new List<Command>(magic);
    }

    public override string name {
        get {
            return "White Magic";
        }
    }
     
}
