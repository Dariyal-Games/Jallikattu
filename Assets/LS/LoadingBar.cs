using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBar : MonoBehaviour
{

    AsyncOperation ao;
    public GameObject LoadingScreenBG;
    public Slider ProgBar;
    public Text LoadingText;

    public bool isFakeLoadingBar = false;
    public float fakeIncrement = 0f;
    public float fakeTiming = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadSceneAsync(string GameScene) //scene name to be loaded
    {
        LoadingScreenBG.SetActive(true);
        ProgBar.gameObject.SetActive(true);
        LoadingText.gameObject.SetActive(true);
        LoadingText.text = "Loading...";

        if (!isFakeLoadingBar)
        {
            StartCoroutine(LoadLevelWithRealProgress(GameScene)); //scene name to be loaded
        }
        else
        {

        }

    }

    IEnumerator LoadLevelWithRealProgress(string GameScene) //scene name to be loaded
    {
        ao = SceneManager.LoadSceneAsync(GameScene); //scene name to be loaded
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            ProgBar.value = ao.progress;

            if (ao.progress >= 0.9f)
            {
                LoadingText.text = "Tap To Continue";
                //if (Input.GetKeyDown (KeyCode.F)) 
                {
                    ao.allowSceneActivation = true;
                }
            }

            Debug.Log(ao.progress);
            yield return null;
        }
    }
}
