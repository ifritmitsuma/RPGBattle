using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vivi : Player
{
    private List<Command> skills = new List<Command>();

    public Vivi() {

        this.charName = "Vivi";
        this.level = 38;
        this.hp = 1940;
        this.mp = 207;
        this.maxHp = 1940;
        this.maxMp = 207;
        this.stats = new Dictionary<Stats, int> {
            {Stats.STRENGTH, 29},
            {Stats.SPEED, 19},
            {Stats.MAGIC, 40},
            {Stats.SPIRIT, 26},
            {Stats.ATTACK, 29},
            {Stats.DEFENSE, 25},
            {Stats.EVADE, 25},
            {Stats.MAGIC_DEFENSE, 29},
            {Stats.MAGIC_EVADE, 14},
        };

        this.skills.Add(new BlackMagicCommand(new List<Skill>{
            new Fire(),
            new Fira(),
            new Blizzard(),
            new Blizzara(),
            new Thunder(),
            new Thundara()
        }));
        this.skills.Add(new FocusCommand());

        this.frontRow = false;
    }

    public override List<Command> GetSkills() {
        return this.skills;
    }
}
