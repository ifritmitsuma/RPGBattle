using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : Skill
{

    public override string name {
        get {
            return "Thunder";
        }
    }

    public Thunder() : base() {
        this.element = Element.LIGHTNING;
        this.damage = 20;
        this.mpCost = 4;
        this.heal = false;
        this.effectName = "Thunder";
    }

}
