using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthCamScript : MonoBehaviour
{
    // Start is called before the first frame updatevar newSprite : Sprite;
    public Sprite coconut;
    public Sprite sand;
    public Sprite raft;
    // public Sprite sand;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (TongueAttack.objInMouthTracker == "Coconut")
        {
            GetComponent<SpriteRenderer>().sprite = coconut;
        }
        
        else if (TongueAttack.objInMouthTracker == "Raft")
        {

            GetComponent<SpriteRenderer>().sprite = raft;

        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = null;
        }

    }
}
