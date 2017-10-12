using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {
	public GameObject pauseCanvas;
	public bool isPaused = false;


	public void Start()
	{
		pauseCanvas.SetActive (false);
	}

	public void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Debug.Log ("WWW");
			isPaused = !isPaused;
		}
		if (isPaused == true) {
			Time.timeScale = 0.0f;
			pauseCanvas.SetActive (true);
		} else if (isPaused == false) 
		{
			Time.timeScale = 1.0f;
			pauseCanvas.SetActive (false);
			
		}
	}

	public void ResumeGame()
	{
		isPaused = false;
	}
	public void ExitGame()
	{
        SceneManager.LoadScene(1);
	}

    public void mainmenu()
    {
        SceneManager.LoadScene(0);
    }

    public void stop()
    {
        isPaused = !isPaused;


        if (isPaused == true)
        {
            Time.timeScale = 0.0f;
            pauseCanvas.SetActive(true);
        }
        else if (isPaused == false)
        {
            Time.timeScale = 1.0f;
            pauseCanvas.SetActive(false);

        }
    }

}
