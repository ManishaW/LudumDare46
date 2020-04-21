using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitItemInstantiateScript : MonoBehaviour
{
    public GameObject coconutClone;
    // Start is called before the first frame update
    void Start()
    {
        
        Instantiate (coconutClone, transform);
    }

    // Update is called once per frame
    void Update()
    {
        // if (TongueAttack.objInMouthTracker == "raft")
        // {

        // }
    }
}
