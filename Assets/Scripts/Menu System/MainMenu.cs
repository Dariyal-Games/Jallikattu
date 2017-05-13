using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text[] scoreText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Options()
    {
        SceneManager.LoadScene("GameScene");
        // for now we havnt any option list so when  it is ready we will replace with the option scene name.
    }

    public void Leave()
    {
        Application.Quit();
    }

    public void ShowScores()
    {
        for (int i = 0; i < 5; i++)
        {

            scoreText[i].text = HiScore.Instance.HiScores[i].ToString();
        }
    }

}
