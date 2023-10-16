using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blizzara : Skill
{

    public override string name {
        get {
            return "Blizzara";
        }
    }

    public Blizzara() : base() {
        this.element = Element.ICE;
        this.damage = 50;
        this.mpCost = 10;
        this.heal = false;
        this.effectName = "Blizzara";
    }

}
