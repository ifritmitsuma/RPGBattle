using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Item
{

    public override bool usable {
        get {
            return false;
        }
    }

}
