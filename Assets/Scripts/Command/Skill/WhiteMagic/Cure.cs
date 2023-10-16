using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cure : Skill
{

    public override string name {
        get {
            return "Cure";
        }
    }

    public Cure() : base() {
        this.damage = 50;
        this.mpCost = 4;
        this.heal = true;
        this.effectName = "Cure";
    }

    public override void affect() {
        foreach(Character target in targets) {
            if(target.isDead()) {
                guiManager.showDamage(target, "MISS", heal);
            } else {
                base.affect();
            }
        }
    }

}
