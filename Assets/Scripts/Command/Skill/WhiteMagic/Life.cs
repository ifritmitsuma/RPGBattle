using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : Skill
{

    public override string name {
        get {
            return "Life";
        }
    }

    public Life() : base() {
        this.damage = 1;
        this.mpCost = 7;
        this.heal = true;
        this.effectName = "Life";
    }

    public override void affect() {
        foreach(Character target in targets) {
            if(!target.isDead()) {
                guiManager.showDamage(target, "MISS", heal);
            } else {
                base.affect();
            }
        }
    }

}
