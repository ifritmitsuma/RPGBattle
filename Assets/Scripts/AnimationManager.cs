using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
 
    private static AnimationManager instance;
    public List<GameObject> effectPrefabs;

    public Canvas uiCanvas;
    
    void Awake() {
        AnimationManager.instance = this;
    }
    
    public static AnimationManager get() {
        return AnimationManager.instance;
    }

    public void animate(string effectName, Vector2 position) {
        //Vector3 screenPos = Camera.main.WorldToScreenPoint(position);
        GameObject prefab = Instantiate(effectPrefabs.Find(e => e.name == effectName), new Vector3(position.x, position.y, 0), Quaternion.identity);
        
    }

}
