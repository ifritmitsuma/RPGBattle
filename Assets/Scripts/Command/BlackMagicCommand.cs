using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMagicCommand : SubCommand
{
    
    public BlackMagicCommand(List<Skill> magic) {
        this.list = new List<Command>(magic);
    }

    public override string name {
        get {
            return "Black Magic";
        }
    }
    
}
