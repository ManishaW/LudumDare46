using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public static string objInMouthTracker = "";
    public GameObject spitItemClone;
    public GameObject raftMain;
    int gotSand = 0;
    void Start()
    {
        objInMouthTracker = "";
        Level1Script.foundVases = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
 
    void OnTriggerEnter2D(Collider2D col)
    {
        //if its a vase, break
        if (col.gameObject.name == "DemonVase")
        {
            Destroy(col.gameObject);
            Level1Script.foundVases = Level1Script.foundVases + 1;

        }
        else if (col.gameObject.name == "Coconut")
        {
            Destroy(col.gameObject);
            PlayerMovement.itemInMouth = true;
            objInMouthTracker = "Coconut";
           //call something in player movement script to instantiate the spitItem

        }
        else if (col.gameObject.name == "RaftSand")
        {
            Vector3 shrinkSand = new Vector3(-0.1f, -0.1f, -0.1f);
            col.gameObject.transform.localScale += shrinkSand;
            // gotSand +=1;

            if (col.gameObject.transform.localScale.x < 0.4)
            {
                col.gameObject.SetActive(false);
                raftMain.GetComponent<Collider2D>().enabled = true;
                

            }

        }
        if (col.gameObject.name == "Raft")
        {
            Destroy(col.gameObject);
            PlayerMovement.itemInMouth = true;
            objInMouthTracker = "Raft";

        }
    }
   
}
