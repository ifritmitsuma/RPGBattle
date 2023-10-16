using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zaghnol : Foe
{
    private List<Command> skills = new List<Command>();

    public Zaghnol() {

        this.charName = "Zaghnol";
        this.level = 60;
        this.hp = 13206;
        this.mp = 2550;
        this.maxHp = 13206;
        this.maxMp = 2550;
        this.stats = new Dictionary<Stats, int> {
            {Stats.STRENGTH, 22},
            {Stats.SPEED, 50},
            {Stats.MAGIC, 22},
            {Stats.SPIRIT, 39},
            {Stats.ATTACK, 87},
            {Stats.DEFENSE, 10},
            {Stats.EVADE, 6},
            {Stats.MAGIC_DEFENSE, 10},
            {Stats.MAGIC_EVADE, 8},
        };

        this.items.Add(new Potion(), 2500);
        this.items.Add(new HiPotion(), 5000);
        this.items.Add(new SaveTheQueen(), 2500);

        Command attack = new AttackCommand();
        attack.source = this;
        this.skills.Add(attack);

    }

    public override List<Command> GetSkills() {
        return this.skills;
    }

    public override Command executeAI(List<Player> players, List<Foe> foes) {
        Command command = this.skills.Find(skill => skill.name == "Attack");
        command.targets = new List<Character>{players[Random.Range(0, players.Count - 1)]};
        return command;
    }

}
