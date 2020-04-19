using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthCamScript : MonoBehaviour
{
    // Start is called before the first frame updatevar newSprite : Sprite;
    public Sprite newSprite;
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (TongueAttack.objInMouthTracker=="coconut"){
             GetComponent<SpriteRenderer>().sprite = newSprite;
        }else{
             GetComponent<SpriteRenderer>().sprite = null;
        }

    }
}
