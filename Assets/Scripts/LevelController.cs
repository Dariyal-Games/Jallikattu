using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dariyal.Jallikattu
{
    public class LevelController : MonoBehaviour
    {
        public PowerUpGenerator.Settings powerupSettings;

        // Use this for initialization
        void Start()
        {
            var powerupGen = FindObjectOfType<PowerUpGenerator>();
            powerupGen.Init(powerupSettings);


        }

        public void OnGameOver()
        {
            //pause and show go panel.
        }
    }
}