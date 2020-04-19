using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public static string objInMouthTracker = "";
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);


        //if its a vase, break
        if (col.gameObject.name == "DemonVase")
        {
            Destroy(col.gameObject);

        }
        else if (col.gameObject.name == "coconut")
        {
            Destroy(col.gameObject);
            PlayerMovement.itemInMouth = true;
            objInMouthTracker = "coconut";


        }
        //if its a cocount, attach

    }
}
