using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dariyal.Jallikattu
{
    public class StaminaManager : MonoBehaviour
    {

        public static Image staminaBar;

        private void Start()
        {
            staminaBar = GameObject.Find("staminaBar").GetComponent<Image>();
        }

        void Update()
        {
            if ( SpeedBoost.onBoostMode)
            {
                staminaBar.fillAmount -= 1.0f / 15f * Time.deltaTime;       //boost --> lower the value boosts
            }
            else
            {
                staminaBar.fillAmount -= 1.0f / 100f * Time.deltaTime;  //normal 
            }
            

            if (staminaBar.fillAmount <= 0)
            {
                print("game over");
            }
        }
    }
}