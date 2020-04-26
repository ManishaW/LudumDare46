using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmTreeScript : MonoBehaviour
{
    public GameObject coconutFall;
    public GameObject coconutFallClone;
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
        Debug.Log("in the trigger!");
        //if its a vase, break
        if (col.gameObject.name == "Player")
        {
            coconutFallClone = Instantiate(coconutFall, transform);
            coconutFallClone.GetComponent<Rigidbody2D>().gravityScale = 2;
            coconutFallClone.gameObject.name="Coconut";
            Invoke("LifetimeCoconut", 2.0f);
        }
     

    }
    void LifetimeCoconut (){
        Destroy(coconutFallClone);
    }
}
