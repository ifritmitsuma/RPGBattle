using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zidane : Player
{
    private List<Command> skills = new List<Command>();

    public Zidane() {

        this.charName = "Zidane";
        this.level = 46;
        this.hp = 3291;
        this.maxHp = 3291;
        this.mp = 198;
        this.maxMp = 198;
        this.stats = new Dictionary<Stats, int> {
            {Stats.STRENGTH, 41},
            {Stats.SPEED, 27},
            {Stats.MAGIC, 35},
            {Stats.SPIRIT, 38},
            {Stats.ATTACK, 44},
            {Stats.DEFENSE, 24},
            {Stats.EVADE, 17},
            {Stats.MAGIC_DEFENSE, 28},
            {Stats.MAGIC_EVADE, 11},
        };

        this.skills.Add(new StealCommand());
        this.skills.Add(new SkillCommand());

        this.frontRow = true;
    }

    public override List<Command> GetSkills() {
        return this.skills;
    }

}
