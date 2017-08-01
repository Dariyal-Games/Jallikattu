using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Dariyal.Jallikattu
{
    [RequireComponent(typeof(Stats))]
    public class PlayerMovement : MonoBehaviour
    {
        float currentSpeed = 10;
        float maxAngle = 20;
        float minAngle = -20;
        float minSpeed = 5;
        float maxSpeed = 20;
        float acceleration = 10;
        float deceleration = 1;
        float turnRate = 30f;
        bool LTap;
        bool RTap;
        bool press;
        Transform lWall;
        Transform rWall;

        Stats bullStats;

        public float CurrentSpeed
        {
            get
            {
                return currentSpeed;
            }

            set
            {
                currentSpeed = value;
            }
        }

        // Use this for initialization
        void Start()
        {
            bullStats = GetComponent<Stats>();
            currentSpeed = bullStats.MaxSpeed;

            GameObject lhitgo = GameObject.Find("lWall");
            if (lhitgo == null) throw new System.Exception("lWall not found in scene. Add it.");
            GameObject rhitgo = GameObject.Find("rWall");
            if (rhitgo == null) throw new System.Exception("rWall not found in scene. Add it.");

            rWall = rhitgo.transform;
            lWall = lhitgo.transform;
        }

        // Update is called once per frame
        void Update()
        {
            bool lHit = transform.position.x < -0.6f;
            bool rHit = transform.position.x > 0.6f;

            if (CrossPlatformInputManager.GetButtonDown("Right"))
            {
                RTap = true;
            }
            if (CrossPlatformInputManager.GetButtonUp("Right"))
            {
                RTap = false;
                transform.rotation = Quaternion.identity;
            }
            if (RTap)
            {
                float rotY = (transform.eulerAngles.y) * bullStats.TurnRate * Time.deltaTime;
                Debug.Log(rotY);
                if (rHit)
                    transform.rotation = Quaternion.identity;
                else if (rotY < maxAngle)
                    transform.Rotate(transform.up, bullStats.TurnRate * Time.deltaTime);

            }


            if (CrossPlatformInputManager.GetButtonDown("Left"))
            {
                LTap = true;
            }
            if (CrossPlatformInputManager.GetButtonUp("Left"))
            {
                transform.rotation = Quaternion.identity;
                LTap = false;
            }
            if (LTap)
            {
                float rotY = transform.eulerAngles.y != 0f ? (transform.eulerAngles.y - 360f) * bullStats.TurnRate * Time.deltaTime : 0;
                Debug.Log(rotY);
                if (lHit)
                    transform.rotation = Quaternion.identity;
                else if (rotY > minAngle)
                    transform.Rotate(transform.up, -bullStats.TurnRate * Time.deltaTime);
            }

            //currentSpeed = Mathf.Clamp(currentSpeed, bullStats.MinSpeed, bullStats.MaxSpeed);
            transform.Translate(transform.forward * currentSpeed * Time.deltaTime);
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

        public IEnumerator TemporarySpeedBoost(float deltaSpeed, float duration)
        {
            float oldSpeedValue = currentSpeed;
            currentSpeed += deltaSpeed;
            yield return new WaitForSeconds(duration);
            currentSpeed = oldSpeedValue;
        }

        public void AddTemporarySpeedBoost(float deltaSpeed, float duration)
        {
            //StopCoroutine("TemporarySpeedBoost");
            StartCoroutine(TemporarySpeedBoost(deltaSpeed, duration));
        }
    }
}