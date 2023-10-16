using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ATBManager
{

    public void push(Command command);

    public void update();

    public int getATBValue(Character character);

    public bool tick(Character character);

    public void clear(Character character);

}
