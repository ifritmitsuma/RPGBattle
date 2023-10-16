using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class CharacterController : MonoBehaviour
{

    public GameObject battleHelperObject;

    protected Character character;

    protected bool dead;

    // Start is called before the first frame update
    protected virtual void Start()
    {
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        Animator anim = gameObject.GetComponent<Animator>();
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        if(character.isDead() && !dead) {
            dead = true;
            anim.SetTrigger(CharacterAnimation.DIE.ToString());
        }

        if(dead && !character.isDead()) {
            dead = false;
            anim.SetTrigger(CharacterAnimation.REVIVE.ToString());
        }
    }

    public void castAnimation() {
        Animator anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger(CharacterAnimation.CAST.ToString());
    }

}
