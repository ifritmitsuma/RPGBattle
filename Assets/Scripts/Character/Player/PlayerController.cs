using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class PlayerController : CharacterController
{

    public string characterName;

    // Start is called before the first frame update
    protected override void Start()
    {
        BattleHelper battleHelper = battleHelperObject.GetComponent<BattleHelper>();
        character = (Player) System.Activator.CreateInstance(System.Type.GetType(gameObject.name));
        character.gameObject = gameObject;
        if(!string.IsNullOrEmpty(characterName)) {
            character.charName = characterName;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = battleHelper.GetCharacterSprite(gameObject.name);

        if(!((Player) character).frontRow) {
            gameObject.transform.position += new Vector3(GameObject.Find("Positions").GetComponent<RectTransform>().rect.width, 0, 0);
        }
    }

    public Player GetPlayer() {
        return (Player) character;
    }
}
