using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float currentSpeed = 10;
    float minSpeed = 5;
    float maxSpeed = 20;
    float acceleration = 10;
    float deceleration = 1;
    float turnRate = 30f;
    bool LTap;
    bool RTap;
    bool press;

    Stats bullStats;


    // Use this for initialization
    void Awake()
    {
        bullStats = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * currentSpeed * Time.deltaTime);
        Quaternion tempRot = Quaternion.identity;
        float t = 0;
        if (CrossPlatformInputManager.GetButtonDown("Right"))
        {
            //var posi = transform.position;
            //posi.x = transform.position.x + turnRadius * Time.deltaTime;
            //transform.position = posi;

            //Quaternion target = Quaternion.Euler(0, turnRadius , 0);
            //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 2.0f);

            transform.Rotate(transform.up, bullStats.TurnRate * Time.deltaTime);
            RTap = true;

        }

        if (CrossPlatformInputManager.GetButtonUp("Right"))
        {
            RTap = false;
            transform.rotation = Quaternion.identity;
            t = 0;
        }
        if (RTap == true)
            transform.Rotate(transform.up, +bullStats.TurnRate * Time.deltaTime);



        if (CrossPlatformInputManager.GetButtonDown("Left"))
        {
            //    var posi = transform.position;
            //    posi.x = transform.position.x - turnRate * Time.deltaTime;
            //    transform.position = posi;

            //    Quaternion target = Quaternion.Euler(0, -turnRate, 0);
            //    transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 2.0f);
            LTap = true;
        }

        if (CrossPlatformInputManager.GetButtonUp("Left"))
        {
            transform.rotation = Quaternion.identity;
            LTap = false;
        }

        if (LTap == true)
            transform.Rotate(transform.up, -bullStats.TurnRate * Time.deltaTime);


    }


    void Accelerate()
    {
        currentSpeed += bullStats.Accelertion;
        currentSpeed = Mathf.Clamp(currentSpeed, bullStats.MinSpeed, bullStats.MaxSpeed);
    }


    void Decelerate()
    {
        currentSpeed -= bullStats.Deceleration;
        currentSpeed = Mathf.Clamp(currentSpeed, bullStats.MinSpeed, bullStats.MaxSpeed);
    }


}
