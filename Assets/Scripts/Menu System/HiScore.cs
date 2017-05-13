using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HiScore : MonoBehaviour
{
    private static HiScore _instance;

    public static HiScore Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<HiScore>();
                if (_instance == null)
                {
                    _instance = new GameObject("HiScores").AddComponent<HiScore>();
                    DontDestroyOnLoad(_instance.gameObject);
                }
            }

            return _instance;
        }
    }

    int[] hiScores;
    string hiScoreKey = "hiscore";

    public int[] HiScores
    {
        get
        {
            return hiScores;
        }
    }

    // Use this for initialization
    void Start()
    {
        hiScores = new int[5];

        for (int i = 0; i < 5; i++)
        {
            hiScores[i] = PlayerPrefs.GetInt(hiScoreKey + (i + 1).ToString(), 0);
        }
    }


    private void OnApplicationQuit()
    {
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt(hiScoreKey + (i + 1).ToString(), hiScores[i]);
        }
    }

    public void SaveHiScore()
    {
        int currentScore = ScoreManager.Instance.GetScore();

        for (int i = 0; i < 5; i++)
        {
            if (currentScore > hiScores[i])
            {
                hiScores[i] = currentScore;
                break;
            }
        }
    }
}
