using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

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
        SceneManager.LoadScene("SampleScene");
    }

    public void Options()
    {
        SceneManager.LoadScene("GameScene");
        // for now we havnt any option list so when  it is ready we will replace with the option scene name.
    }

}
