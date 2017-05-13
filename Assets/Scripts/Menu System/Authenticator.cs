using GooglePlayGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Authenticator : MonoBehaviour
{



    private void Start()
    {
        PlayGamesPlatform.Activate();
        SignIn();
    }
    public void SignIn()
    {
        if (!Social.localUser.authenticated)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    Debug.Log("User Signed In");
                }
                else
                {
                    Debug.LogError("Error signing in");
                }
            });
        }
    }
}
