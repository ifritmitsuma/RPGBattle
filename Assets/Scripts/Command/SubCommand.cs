using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SubCommand : Command
{

    protected List<Command> list = new List<Command>();

    protected List<Command> itemList = new List<Command>();

    public override List<Command> subMenu {
        get {
            if(this is ItemCommand) {
                return itemList;
            }
            return list;
        }
    }

    public override void affect()
    {
        return;
    }
}
