using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thundara : Skill
{

    public override string name {
        get {
            return "Thundara";
        }
    }

    public Thundara() : base() {
        this.element = Element.LIGHTNING;
        this.damage = 50;
        this.mpCost = 10;
        this.heal = false;
        this.effectName = "Thundara";
    }

}
