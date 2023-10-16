using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stats 
{
    // Passive
    STRENGTH, SPEED, MAGIC, SPIRIT,

    // Active
    ATTACK, DEFENSE, EVADE, MAGIC_DEFENSE, MAGIC_EVADE
    
}

public class StatsFormulas {

    public static int physicalDamage(Character source, Character target) {
        int baseDamage = Mathf.Max(0, source.stats[Stats.ATTACK] - (target.stats[Stats.DEFENSE] + (target.stats[Stats.DEFENSE] * target.modifiers[Stats.DEFENSE] / 100)));
        int strength = source.stats[Stats.STRENGTH];
        int bonusDamage = strength + Random.Range(0, ((source.level + strength) / (source is Foe ? 4 : 8)) + 1);

        int damage = Mathf.Min((baseDamage == 0 ? 1 : baseDamage) * bonusDamage, 9999);

        if(target is Player) {
            damage /= ((Player) target).frontRow ? 1 : 2;
        } else if(source is Player) {
            damage /= ((Player) source).frontRow ? 1 : 2;
        }

        return damage;
    }

    public static int magicDamage(Character source, Character target, Skill skill) {
        int baseDamage = Mathf.Max(0, skill.getDamage() - target.stats[Stats.MAGIC_DEFENSE]);
        int magic = source.stats[Stats.MAGIC];
        int bonus = magic + Random.Range(0, ((source.level + magic) / 8) + 1);

        return Mathf.Min((baseDamage == 0 ? 1 : baseDamage) * bonus, 9999);
    }

    public static int statusInduceTime(Character source) {
        return 0;
    }

}
