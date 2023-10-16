using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHelper : MonoBehaviour
{

    public Texture2D characterSpritesheet;

    public Texture2D foeSpritesheet;

    private Sprite[] characterSprites;
    
    private Sprite[] foeSprites;

    public AnimationClip[] animations;

    // Start is called before the first frame update
    void Awake()
    {
        characterSprites = Resources.LoadAll<Sprite>("GFX/Sprites/" + characterSpritesheet.name);
        foeSprites = Resources.LoadAll<Sprite>("GFX/Sprites/" + foeSpritesheet.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Sprite GetSprite(Sprite[] sprites, string name) {
        return System.Array.Find<Sprite>(sprites, s => s.name == name);
    }

    public Sprite GetCharacterSprite(string name) {
        return GetSprite(characterSprites, name);
    }

    public Sprite GetFoeSprite(string name) {
        return GetSprite(foeSprites, name);
    }

    public AnimationClip GetAnimationClip(CharacterAnimation charAnim) {
        return System.Array.Find<AnimationClip>(animations, a => a.name.ToUpper() == charAnim.ToString());
    }
    
}
