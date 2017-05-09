using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SampleScript : MonoBehaviour
{

    public Text ScoreText;
    //private int MyScore;

    private void Update()
    {
        ScoreText.text = ScoreManager.Instance.GetScore().ToString();

    }

    public void Increase()
    {
        ScoreManager.Instance.AdjustScore(5);
    }

    public void Decrease()
    {
        ScoreManager.Instance.AdjustScore(-1);
    }

    public void End()
    {
        Social.ReportScore(ScoreManager.Instance.GetScore(), GPGSIds.leaderboard_hi_score, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Hi Score added sucessfully.");
            }
            else
            {
                Debug.LogError("Hi Score couldnot be updaed.");
            }
        });
        SceneManager.LoadScene("Main Menu");
    }
}
