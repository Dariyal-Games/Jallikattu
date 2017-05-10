using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerSystem : MonoBehaviour
{

    public float ShrugFailTIme = 3f;
    float gameTime;
    float bullAttackTime;

    bool bullBeingAttacked;

    // Use this for initialization
    void Start()
    {
        gameTime = 0;
        Messenger.AddListener("Bull Attacked", BullAttacked);
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        if (bullBeingAttacked)
        {
            bullAttackTime += Time.deltaTime;

            if (bullAttackTime >= ShrugFailTIme)
            {
                ScoreManager.Instance.SetScore((int)gameTime);
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
                SceneManager.LoadScene("MainMenu");
            }
        }

    }
    public void BullAttacked()
    {
        bullBeingAttacked = true;
        bullAttackTime = 0;
    }

    public void BullReleased()
    {
        bullBeingAttacked = false;
    }
}
