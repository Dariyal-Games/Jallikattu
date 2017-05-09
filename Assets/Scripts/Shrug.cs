using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Shrug : MonoBehaviour
{


    public GameObject attacker;
    AttackerController attackerStrength;


    Stats bullStats;



    void Awake()
    {
        attackerStrength = GetComponent<AttackerController>();
    }





    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        float strengthValue;
        float shrugCalc = 0;
        float bullStrength = bullStats.Shrug * 2;

        strengthValue = bullStats.Shrug - attackerStrength.attackStrength * 2;

        if (CrossPlatformInputManager.GetButtonDown("Space"))
        {
            shrugCalc = bullStrength - strengthValue;
        }

        if (shrugCalc <= 0)
            transform.parent = null;
    }
}
