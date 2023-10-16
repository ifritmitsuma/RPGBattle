using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSword : Skill
{

    public override string name {
        get {
            return "Blood Sword";
        }
    }

    public BloodSword() : base() {
        this.physical = true;
        this.damage = 20;
        this.mpCost = 4;
        this.heal = false;
        this.absorb = true;
    }

}
