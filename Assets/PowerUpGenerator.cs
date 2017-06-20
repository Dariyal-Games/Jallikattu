using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGenerator : MonoBehaviour
{

    public GameObject speedPower;

    float minRange = -0.5f;
    float maxRange = 0.5f;

    float powerUpTime = 10f;

    Vector3 powerUpPosition;

    
    // Update is called once per frame
    void Update()
    {

        powerUpPosition = new Vector3(Random.Range(minRange, maxRange), transform.position.y, transform.position.z);

        powerUpTime -= Time.deltaTime;

        if (powerUpTime <= 0)
        {
            Debug.Log("Timer Script");
            Instantiate(speedPower, powerUpPosition, Quaternion.identity);
            powerUpTime = 10f;
        }
    }
}
