using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiPotion : Item
{

    public HiPotion() : base() {
        this.fixedDamage = 150;
        this.heal = true;
    }

    public HiPotion(int count) : this() {
        this.count = count;
    }

    public override string name {
        get {
            return "Hi Potion";
        }
    }

    public override Avatar icon {
        get {
            return null;
        }
    }

    public override string description {
        get {
            return "Cures 450HP of a Party Member";
        }
    }

}
