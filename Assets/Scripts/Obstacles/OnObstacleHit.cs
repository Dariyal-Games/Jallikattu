using Dariyal.Jallikattu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnObstacleHit : MonoBehaviour
{
    private LevelController levelController;

    public GameObject gameOverPanel;

    private bool waitForPlayerResponse = false;

    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        gameOverPanel.SetActive(false);
        PauseGame.isPaused = false;        
    }

    
    void Update()
    {
        if(waitForPlayerResponse || PauseGame.isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("CollisionEntered");
        if (col.gameObject.tag == "Obstacle")
        {
            waitForPlayerResponse = true;
            gameOverPanel.SetActive(true);            
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
