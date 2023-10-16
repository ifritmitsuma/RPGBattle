using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FoeController : CharacterController
{

    // Start is called before the first frame update
    protected override void Start()
    {
        BattleHelper battleHelper = battleHelperObject.GetComponent<BattleHelper>();
        character = (Foe) System.Activator.CreateInstance(System.Type.GetType(gameObject.name));
        character.gameObject = gameObject;
        gameObject.GetComponent<SpriteRenderer>().sprite = battleHelper.GetFoeSprite(gameObject.name);
    }

    public Foe GetFoe() {
        return (Foe) character;
    }

}
