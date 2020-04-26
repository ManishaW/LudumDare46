using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRaftShore : MonoBehaviour
{
    public GameObject RaftToShore;
    public Animator foregroundWaves;
    // Start is called before the first frame update
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
        if (col.gameObject.name == "Raft")
        {
            Debug.Log("trigger raft anim");
            Destroy(col.gameObject);
            RaftToShore.SetActive(true);
            gameObject.GetComponent<Collider2D>().isTrigger = false;
            foregroundWaves.SetTrigger("StopWaves");
            
        }
    }
}
