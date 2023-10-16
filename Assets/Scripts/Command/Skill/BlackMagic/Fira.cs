using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fira : Skill
{

    public override string name {
        get {
            return "Fira";
        }
    }

    public Fira() : base() {
        this.element = Element.FIRE;
        this.damage = 50;
        this.mpCost = 10;
        this.heal = false;
        this.effectName = "Fira";
    }

}
