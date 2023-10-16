using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordArtCommand : SubCommand
{
    
    public SwordArtCommand(List<Skill> magic) {
        this.list = new List<Command>(magic);
    }
    
    public override string name {
        get {
            return "Sword Art";
        }
    }
    
}
