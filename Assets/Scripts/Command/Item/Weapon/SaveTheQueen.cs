using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTheQueen : Weapon
{

    public SaveTheQueen() : base() {
    }

    public SaveTheQueen(int count) : this() {
        this.count = count;
    }

    public override string name {
        get {
            return "Save The Queen";
        }
    }

    public override Avatar icon {
        get {
            return null;
        }
    }

    public override string description {
        get {
            return "The only sword worthy enough to protect the Queen";
        }
    }

}
