using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steiner : Player
{
    private List<Command> skills = new List<Command>();

    public Steiner() {

        this.charName = "Steiner";
        this.level = 43;
        this.hp = 3569;
        this.mp = 160;
        this.maxHp = 3569;
        this.maxMp = 160;
        this.stats = new Dictionary<Stats, int> {
            {Stats.STRENGTH, 41},
            {Stats.SPEED, 22},
            {Stats.MAGIC, 29},
            {Stats.SPIRIT, 30},
            {Stats.ATTACK, 46},
            {Stats.DEFENSE, 29},
            {Stats.EVADE, 17},
            {Stats.MAGIC_DEFENSE, 17},
            {Stats.MAGIC_EVADE, 26},
        };

        this.skills.Add(new SwordArtCommand(new List<Skill>{
            new BloodSword()
        }));
        this.skills.Add(new SwordMagicCommand());

        this.frontRow = true;
    }

    public override List<Command> GetSkills() {
        return this.skills;
    }
}
