using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Foe : Character
{

    protected int xp;

    protected int ap;

    protected int gil;

    protected Dictionary<Item, int> items = new Dictionary<Item, int>();

    protected Dictionary<Item, int> drops = new Dictionary<Item, int>();

    public int getXP() {
        return xp;
    }

    public int getAP() {
        return ap;
    }

    public int getGil() {
        return gil;
    }

    public Dictionary<Item, int> getItems() {
        return items;
    }

    public List<Item> getDrops() {
        
        List<Item> items = new List<Item>();

        foreach(Item item in drops.Keys) {
            if(Random.Range(0, 100) * 100 - drops[item] <= 0) {
                items.Add(item);
            }
        }

        return items;

    }

    public abstract Command executeAI(List<Player> players, List<Foe> foes);

}
