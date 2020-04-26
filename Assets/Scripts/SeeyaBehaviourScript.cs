using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeyaBehaviourScript : MonoBehaviour
{
    public Animator animator;
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
        if (col.gameObject.name == "Coconut")
        {
            Destroy(col.gameObject);
            //trigger mad seeya
            animator.SetTrigger("IsAngry");

        }

        //   col.gameObject.transform.parent = gameObject.transform;
    }
}
