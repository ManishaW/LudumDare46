using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    Animator animatorTongue;
    public GameObject tongue;
    public GameObject inMouthObj;
    Rigidbody2D inMouthObjRb;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public static bool itemInMouth = false;
    float directionFacing =0;

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetAxisRaw("Horizontal")!=0){
            directionFacing = Input.GetAxisRaw("Horizontal");
            // Debug.Log(directionFacing);
        }
        animatorTongue = tongue.GetComponent<Animator>();
        // animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;

            // animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            Debug.Log("crouch");
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            Debug.Log("uncrouch");

        }


        if (itemInMouth)
        {
            if (Input.GetButtonDown("Tongue"))
            {
                TongueAttack.objInMouthTracker ="";
                inMouthObj.SetActive(true);
                inMouthObjRb = inMouthObj.GetComponent<Rigidbody2D>();
                //   inMouthObjRb.AddForce(transform.up,ForceMode2D.Impulse);
                inMouthObjRb.gravityScale = 0.5f;
                inMouthObj.transform.parent = null;
                // Calculate trajectory velocity
                Vector3 v = new Vector3(directionFacing*Mathf.Cos(55 * Mathf.Deg2Rad), Mathf.Sin(55 * Mathf.Deg2Rad), Mathf.Cos(55 * Mathf.Deg2Rad));
                inMouthObjRb.velocity = v * Mathf.Sqrt(5 * Physics.gravity.magnitude / Mathf.Sin(2 * 55 * Mathf.Deg2Rad));
                itemInMouth = false;
            }
        }
        else
        {
            if (Input.GetButtonDown("Tongue") && !itemInMouth)
            {
                animatorTongue.SetTrigger("TongueAttack");
            }
        }

    }

    public void OnLanding()
    {
        // animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        // animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
