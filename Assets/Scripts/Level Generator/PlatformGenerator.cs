using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    private Transform generationPoint;
    public Transform currentPlatform;
    public Transform platformHolder;
    public GameObject[] platformPrefabs;
    private Transform player;
    private Transform currentEndPoint;

    // Use this for initialization
    void Start()
    {
        if (currentPlatform == null) throw new System.Exception("Current Platform not set.");
        GameObject pgo = GameObject.FindGameObjectWithTag("Player");
        if (pgo == null) throw new System.Exception("Player not found or tagged.");

        player = pgo.transform;
        currentEndPoint = currentPlatform.Find("EndPoint");

        GameObject gpgo = GameObject.Find("GenerationPoint");
        if (gpgo == null) throw new System.Exception("GenerationPoint not set.");
        generationPoint = gpgo.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEndPoint.position.z < generationPoint.position.z) CreatePlatform();
    }

    public void CreatePlatform()
    {
        GameObject prefab = GetNewRandomPlatform();

        GameObject go = Instantiate(prefab, currentEndPoint.position, Quaternion.identity, platformHolder);
        currentEndPoint = go.transform.Find("EndPoint");
    }

    GameObject GetNewRandomPlatform()
    {
        int index = Random.Range(0, platformPrefabs.Length);
        return platformPrefabs[index];
    }
}
