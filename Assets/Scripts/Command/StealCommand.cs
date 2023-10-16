using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealCommand : Command
{
    public override string name {
        get {
            return "Steal";
        }
    }

    public override void affect()
    {
        foreach(Character target in targets) {

            Foe foe = (Foe) target;
            Dictionary<Item, int> items = foe.getItems();
            foreach(KeyValuePair<Item, int> entry in items) {
                if(Random.Range(0, 10000) < entry.Value) {
                    guiManager.showMessage("Stole " + entry.Key.name, 3.0f);
                    foe.getItems().Remove(entry.Key); 
                    battleManager.getItem(entry.Key);
                    return;               
                }
            }

            guiManager.showMessage("Couldn't steal anything", 3.0f);

        }
    }
}
