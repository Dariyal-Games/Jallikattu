using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private static ScoreManager _instance;
    private int playerScore;

    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreManager>();

                if (_instance == null)
                {
                    _instance = new GameObject("Score Manager").AddComponent<ScoreManager>();
                    //DontDestroyOnLoad(_instance.gameObject);
                }
            }

            return _instance;
        }
    }



    public void AdjustScore(int num)
    {
        playerScore += num;
    }

    public int GetScore()
    {
        return playerScore;
    }
}
