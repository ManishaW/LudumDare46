using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            if (pauseStatus)
            {
                Time.timeScale = 0f;

            }
            else
            {
                Time.timeScale = 1f;

            }
            // animator.SetBool("IsJumping", true);
        }
    }
  
   public void onClickResume()
    {
        pausedCanvas.SetActive(false);
        pauseStatus = false;
        Time.timeScale = 1f;

    }
    public void onClickBackToMM()
    {
        SceneManager.LoadSceneAsync("MainMenu");
        Time.timeScale = 1f;

    }
    public void onClickBegin()
    {
        SceneManager.LoadSceneAsync("Scene1");
    }
    public void onClickExit()
    {
        Application.Quit();
    }
    public void onClickHowToPlay()
    {
        SceneManager.LoadSceneAsync("HowToPlay");

    }

}
