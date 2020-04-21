using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //if its a vase, break
        if (col.gameObject.name == "sandIsland"&& gameObject.name!="Raft2")
        {
            Debug.Log("reach??");
            // col.gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
            gameObject.transform.parent = null;

        }else if (col.gameObject.name == "Ground" && gameObject.name=="Raft2"){
            Debug.Log("hit ground!!");
            gameObject.transform.parent = null;


        }

        //   col.gameObject.transform.parent = gameObject.transform;
    }
}
