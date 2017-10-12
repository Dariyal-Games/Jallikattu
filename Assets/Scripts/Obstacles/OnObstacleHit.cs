using Dariyal.Jallikattu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class OnObstacleHit : MonoBehaviour
{
    private LevelController levelController;

    public GameObject gameOverPanel;

    private bool waitForPlayerResponse = false;

    public bool isGamePaused = false;

    public PauseManager pausing;

    public GameObject button,button1;

    public GameObject gameOverText;
    public GameObject gamePauseText;

    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        //gameOverPanel.SetActive(false);
        pausing.pauseCanvas.SetActive(false);


    }


    void Update()
    {
        //if (waitForPlayerResponse /*|| PauseGame.isPaused*/)
        //{
        //    Time.timeScale = 0;
        //}
        //      else
        //  {
        //         Time.timeScale = 1;
        //     }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("WWW");
            pausing.isPaused = !pausing.isPaused;
        }
        if (pausing.isPaused == true)
        {
            Time.timeScale = 0.0f;
            pausing.pauseCanvas.SetActive(true);
        }
        else if (pausing.isPaused == false)
        {
            Time.timeScale = 1.0f;
            pausing.pauseCanvas.SetActive(false);

        }

    }


    void OnTriggerEnter(Collider col)
    {
        Debug.Log("CollisionEntered");
        if (col.gameObject.tag == "Obstacle")
        {
            //waitForPlayerResponse = true;
            // gameOverPanel.SetActive(true);
            //isGamePaused = !isGamePaused;
            button.SetActive(false);
            button1.SetActive(true);
            gameOverText.SetActive(true);
            gamePauseText.SetActive(false);
            //text.SetActive(false);
            //text.SetActive(true);

            Debug.Log("eee");
            pausing.isPaused = !pausing.isPaused;
        
        if (pausing.isPaused == true)
        {
            Time.timeScale = 0.0f;
            pausing.pauseCanvas.SetActive(true);
        }
        else if (pausing.isPaused == false)
        {
            Time.timeScale = 1.0f;
            pausing.pauseCanvas.SetActive(false);

        }
    }
    }

    public void OnVideoButtonPressed()
    {        
        waitForPlayerResponse = false;
        // play video
                        //      ------> AD <------
        //return here
        this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        gameOverPanel.SetActive(false);        
    }

    public void OnContinueButtonPresses()
    {
        SceneManager.LoadScene(0);  //Main Menu
    }

    public void OnRetryButtonPressed()
    {
        SceneManager.LoadScene(1);
    }
}
