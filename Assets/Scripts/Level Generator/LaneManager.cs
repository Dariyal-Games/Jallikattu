using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour {

    public GameObject[] lanePrefabs;

    private Transform bullTransform;
    private float spawnZ = 0;
    private float laneLength = 37.95f;
    private int lanesOnScreen = 3;


   	// Use this for initialization
	void Start () {
        bullTransform = GameObject.FindGameObjectWithTag("Bull").transform;
		for(int i=0; i<lanesOnScreen; i++)
        {
            SpawnLane();
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
        if(bullTransform.position.z>(spawnZ-lanesOnScreen *laneLength ))
        {
            SpawnLane();
        }		
	}

    
    void SpawnLane(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(lanePrefabs[0]) as GameObject;
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += laneLength;
    }
}
