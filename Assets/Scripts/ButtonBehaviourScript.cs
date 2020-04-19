using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviourScript : MonoBehaviour
{
    public GameObject pausedCanvas;
    bool pauseStatus = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pausedCanvas.SetActive(!pauseStatus);
            pauseStatus = !pauseStatus;
            if (pauseStatus){
             Time.timeScale = 0f;

            }else{
             Time.timeScale = 1f;

            }
            // animator.SetBool("IsJumping", true);
        }
    }
    void onClickPaused()
    {
    }
}
