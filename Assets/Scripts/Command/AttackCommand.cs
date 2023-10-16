using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : Command
{

    public AttackCommand() : base() {

    }

    public override string name {
        get {
            return "Attack";
        }
    }

    public override void affect()
    {
        foreach(Character target in targets) {
            int damage = StatsFormulas.physicalDamage(source, target);
            target.takeDamage(damage);
            animationManager.animate("Attack", target.gameObject.transform.position);
            guiManager.showDamage(target, damage, false);
        }
    }
}
