using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaneManager : MonoBehaviour {

    public GameObject[] lanePrefabs;

    private Transform bullTransform;
    private float spawnZ = 0;
    private float safeZone = 40;
    private float laneLength = 37.95f;
    private int lanesOnScreen = 3;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeLanes;


   	// Use this for initialization
	void Start () {
        activeLanes = new List<GameObject>();
        bullTransform = GameObject.FindGameObjectWithTag("Bull").transform;
		for(int i=0; i<lanesOnScreen; i++)
        {
            if (i < 2)
                SpawnLane(0);
            else 
                SpawnLane();
            
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
        if(bullTransform.position.z-safeZone>(spawnZ-lanesOnScreen *laneLength ))
        {
            SpawnLane();
            DestroyLane();
        }		
	}

    
    void SpawnLane(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(lanePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(lanePrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += laneLength;
        activeLanes.Add(go);
    }


    void DestroyLane()
    {
        Destroy(activeLanes [0]);
        activeLanes.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (lanePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while (randomIndex==lastPrefabIndex)
        {
            randomIndex = Random.Range(0, lanePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;

    }
}
