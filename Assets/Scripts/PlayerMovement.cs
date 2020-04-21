using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    Animator animatorTongue;
    public Animator animator;

    public GameObject tongue;
    GameObject inMouthObj;
    public GameObject spitItemClone;
    Rigidbody2D inMouthObjRb;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    float crouched = 0f;
    bool jump = false;
    public bool crouch = false;
    public static bool itemInMouth = false;
    float directionFacing = 0;

    public Sprite coconut;
    public Sprite raft;
    public GameObject gameOverCanvas;
    public Sprite sandBlob;



    void Start()
    {
        itemInMouth = false;
    }
    // Update is called once per frame
    void Update()
    {

        crouched = Input.GetAxisRaw("Crouch");
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            directionFacing = Input.GetAxisRaw("Horizontal");
            // Debug.Log(directionFacing);
        }
        animatorTongue = tongue.GetComponent<Animator>();

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;

            // animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch") || crouched == 1)
        {
            OnCrouching(true);
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch") || crouched == 0)
        {
            crouch = false;
            OnCrouching(false);


        }


        if (itemInMouth)
        {
            if (Input.GetButtonDown("Tongue"))
            {
                inMouthObj = Instantiate(spitItemClone, transform);
                // newSpitItem.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
                // inMouthObj.SetActive(true);
                inMouthObjRb = inMouthObj.GetComponent<Rigidbody2D>();
                //   inMouthObjRb.AddForce(transform.up,ForceMode2D.Impulse);
                inMouthObjRb.gravityScale = 0.5f;
                inMouthObj.transform.parent = null;
                if (TongueAttack.objInMouthTracker == "Raft")
                {
                    inMouthObj.GetComponent<SpriteRenderer>().sprite = raft;
                    inMouthObj.name = "Raft";
                }
                else if (TongueAttack.objInMouthTracker == "Coconut")
                {
                    inMouthObj.GetComponent<SpriteRenderer>().sprite = coconut;
                    inMouthObj.name = "Coconut";

                }
                // Calculate trajectory velocity
                Vector3 v = new Vector3(directionFacing * Mathf.Cos(45 * Mathf.Deg2Rad), Mathf.Sin(45 * Mathf.Deg2Rad), Mathf.Cos(45 * Mathf.Deg2Rad));
                inMouthObjRb.velocity = v * Mathf.Sqrt(5 * Physics.gravity.magnitude / Mathf.Sin(2 * 45 * Mathf.Deg2Rad));
                itemInMouth = false;
                TongueAttack.objInMouthTracker = "";

            }
        }
        else
        {
            if (Input.GetButtonDown("Tongue") && !itemInMouth)
            {
                if (crouch){
                    animatorTongue.SetTrigger("CrouchedTongueAttack");

                }else{
                    animatorTongue.SetTrigger("TongueAttack");

                }
            }
        }

    }

    public void OnLanding()
    {
        // animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }
    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
    // void OnTriggerEnter2D(Collider2D col)
    // {
    //     if (col.gameObject.name == "DemonVase")
    //     {
    //         Destroy(col.gameObject);

    //     }
    // }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "ReemergeingRaft")
        {
            col.gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
            col.gameObject.name = "FloatingRaft";
            runSpeed = 18;
        }
        else if (col.gameObject.name == "Raft2")
        {
            Debug.Log("player is on the raft");
            col.gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
            // col.gameObject.name = "FloatingRaft2";

        }
        else
        {
            runSpeed = 25; //hmm not sure
        }

        //   col.gameObject.transform.parent = gameObject.transform;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //if its a vase, break
        if (col.gameObject.name == "GameOverTrig")
        {
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0f;
        }

        //   col.gameObject.transform.parent = gameObject.transform;
    }
}
