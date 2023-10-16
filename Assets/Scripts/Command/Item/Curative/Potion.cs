using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item
{

    public Potion() : base() {
        this.fixedDamage = 150;
        this.heal = true;
    }

    public Potion(int count) : this() {
        this.count = count;
    }

    public override string name {
        get {
            return "Potion";
        }
    }

    public override Avatar icon {
        get {
            return null;
        }
    }

    public override string description {
        get {
            return "Cures 150HP of a Party Member";
        }
    }

}
