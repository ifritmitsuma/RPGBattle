using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : Command
{

    public virtual bool usable{
        get {
            return true;
        }
    }

    protected bool multi;

    protected bool heal;

    public Element element;

    public int fixedDamage;

    public int damage;

    public int count;

    public bool isHeal() {
        return heal;
    }

    public abstract Avatar icon {
        get;
    }

    public abstract string description {
        get;
    }

    public override void affect()
    {
        foreach(Character target in targets) {
            if(heal && target.isDead()) {
                guiManager.showDamage(target, "MISS", heal);
            } else {
                int dmg = 0;
                if(fixedDamage > 0) {
                    dmg = fixedDamage;
                } else {
                    //dmg = 
                }
                target.takeDamage(dmg * (heal ? -1 : 1));
                guiManager.showDamage(target, dmg, heal);
            }
            battleManager.useItem(this);
        };
    }

}
