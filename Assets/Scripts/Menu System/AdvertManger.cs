using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvertManger : MonoBehaviour
{


    private static AdvertManger _instance;

    public static AdvertManger Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AdvertManger>();

                if (_instance == null)
                {
                    _instance = new GameObject("AdvertManager").AddComponent<AdvertManger>();
                    DontDestroyOnLoad(_instance.gameObject);
                }
            }

            return _instance;
        }
    }
    void Start()
    {

    }
}
