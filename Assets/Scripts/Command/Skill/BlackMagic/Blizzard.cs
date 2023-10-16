using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blizzard : Skill
{

    public override string name {
        get {
            return "Blizzard";
        }
    }

    public Blizzard() : base() {
        this.element = Element.ICE;
        this.damage = 20;
        this.mpCost = 4;
        this.heal = false;
        this.effectName = "Blizzard";
    }

}
