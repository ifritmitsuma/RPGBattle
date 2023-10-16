using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCommand : SubCommand
{

    public override List<Command> subMenu {
        get {
            return new List<Command>(battleManager.getItems().FindAll(i => i.usable));
        }
    }

    public override string name {
        get {
            return "Item";
        }
    }
}
