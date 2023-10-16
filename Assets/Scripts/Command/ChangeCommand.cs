using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCommand : Command
{
    public override string name {
        get {
            return "Change";
        }
    }

    public override bool isFinal { get {
        return true;
    }}

    public override void affect()
    {
        int multi = ((Player) source).frontRow ? 1 : -1;
        source.gameObject.transform.position += new Vector3(GameObject.Find("Positions").GetComponent<RectTransform>().rect.width * multi, 0, 0);

        ((Player) source).frontRow = !((Player) source).frontRow;

    }
}
