using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{

    public string charName;

    public int level;

    public bool busy {
        get; set;
    }

    public GameObject gameObject;

    public Dictionary<Stats, int> stats = new Dictionary<Stats, int>{
            {Stats.STRENGTH, 0},
            {Stats.SPEED, 0},
            {Stats.MAGIC, 0},
            {Stats.SPIRIT, 0},
            {Stats.ATTACK, 0},
            {Stats.DEFENSE, 0},
            {Stats.EVADE, 0},
            {Stats.MAGIC_DEFENSE, 0},
            {Stats.MAGIC_EVADE, 0},
    };

    public Dictionary<Stats, int> modifiers = new Dictionary<Stats, int>{
            {Stats.STRENGTH, 0},
            {Stats.SPEED, 0},
            {Stats.MAGIC, 0},
            {Stats.SPIRIT, 0},
            {Stats.ATTACK, 0},
            {Stats.DEFENSE, 0},
            {Stats.EVADE, 0},
            {Stats.MAGIC_DEFENSE, 0},
            {Stats.MAGIC_EVADE, 0},
    };

    public int hp;

    protected int maxHp;

    public int mp;

    protected int maxMp;

    public void takeDamage(int damage) {
        this.hp = Mathf.Min(Mathf.Max(0, this.hp - damage), this.maxHp);
    }

    public void takeSpellDamage(int mpDamage) {
        this.mp = Mathf.Min(Mathf.Max(0, this.mp - mpDamage), this.maxMp);
    }

    public bool canUseSpell(int spellCost) {
        return spellCost <= this.mp;
    }

    public bool isDead() {
        return this.hp == 0;
    }

    public void addModifier(Stats stat, int amount) {
        modifiers[stat] += amount;
    }

    public void clearModifier(Stats stat) {
        modifiers[stat] = 0;
    }

    public abstract List<Command> GetSkills();

}
