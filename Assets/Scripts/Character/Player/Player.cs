using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : Character
{

    public Sprite sprite;

    private bool useItems;

    public bool frontRow;

    public bool CanUseItems() {
        return this.useItems;
    }

}
