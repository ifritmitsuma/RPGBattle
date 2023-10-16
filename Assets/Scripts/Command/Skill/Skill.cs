using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : Command
{

    protected Element element;

    protected string effectName = null;

    protected int damage;

    public int mpCost;

    protected bool heal;

    protected bool absorb;

    protected bool physical;

    public Skill() : base() {
        
    }

    public Element GetElement() {
        return this.element;
    }

    public int getDamage() {
        return this.damage;
    }

    public bool isHeal() {
        return this.heal;
    }

    public bool canUserUseSpell() {
        return source.canUseSpell(mpCost);
    }

    public override void affect()
    {
        foreach(Character target in targets) {
            int damage = 0;
            if(physical) {
                damage = StatsFormulas.physicalDamage(source, target);
            } else {
                damage = StatsFormulas.magicDamage(source, target, this);
            }
            source.mp -= Mathf.Max(0, mpCost);
            target.takeDamage(damage * (heal ? -1 : 1));
            if(absorb) {
                source.takeDamage(damage * -1);
                guiManager.showDamage(source, damage, true);
            }
            if(effectName != null) {
                animationManager.animate(effectName, target.gameObject.transform.position);
            }
            guiManager.showDamage(target, damage, heal);
        }
    }

}
