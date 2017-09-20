using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{

    public Text scoreText;

    // Use this for initialization
    void Start()
    {
        if (scoreText == null)
        {
            throw new System.Exception("ScoreText not set.");
        }
    }

    private void Update()
    {
        scoreText.text = ScoreManager.Instance.GetScore().ToString();
    }
}
