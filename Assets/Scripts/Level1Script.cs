using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Script : MonoBehaviour
{
    public GameObject vase1;
    public GameObject vase2;
    public GameObject vase3;
    public static int foundVases;
    bool found1 = false;
    bool found2 = false;
    bool found3 = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (foundVases == 1 && !found1)
        {
            Debug.Log("found");
            vase1.GetComponent<SpriteRenderer>().color = Color.white;
            found1=true;
        }
        if (foundVases == 2 && !found2)
        {
            Debug.Log("found2");
            vase2.GetComponent<SpriteRenderer>().color = Color.white;
            found2=true;
        }
        if (foundVases == 3)
        {
            Debug.Log("found3");
            vase3.GetComponent<SpriteRenderer>().color = Color.white;
            found3=true;
        }
    }
}
