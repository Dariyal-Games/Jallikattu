using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    private Transform destructionPoint;

    // Use this for initialization
    void Start()
    {
        GameObject dpgo = GameObject.Find("DestructionPoint");
        if (dpgo == null) throw new System.Exception("DestructionPoint not set.");
        destructionPoint = dpgo.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < destructionPoint.position.z) Destroy(gameObject);
    }
}
