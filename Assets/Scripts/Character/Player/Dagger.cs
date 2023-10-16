using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : Player
{
    private List<Command> skills = new List<Command>();

    public Dagger() {

        this.charName = "Dagger";
        this.level = 36;
        this.hp = 1900;
        this.mp = 190;
        this.maxHp = 1900;
        this.maxMp = 190;
        this.stats = new Dictionary<Stats, int> {
            {Stats.STRENGTH, 30},
            {Stats.SPEED, 24},
            {Stats.MAGIC, 42},
            {Stats.SPIRIT, 26},
            {Stats.ATTACK, 27},
            {Stats.DEFENSE, 25},
            {Stats.EVADE, 21},
            {Stats.MAGIC_DEFENSE, 31},
            {Stats.MAGIC_EVADE, 16},
        };

        this.skills.Add(new WhiteMagicCommand(new List<Skill> {
            new Cure(),
            new Life()
        }));
        this.skills.Add(new SummonCommand());

        this.frontRow = false;
    }

    public override List<Command> GetSkills() {
        return this.skills;
    }
}
