using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Skill
{

    public override string name {
        get {
            return "Fire";
        }
    }

    public Fire() : base() {
        this.element = Element.FIRE;
        this.damage = 20;
        this.mpCost = 4;
        this.heal = false;
        this.effectName = "Fire";
    }

}
