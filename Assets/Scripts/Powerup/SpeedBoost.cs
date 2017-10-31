using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dariyal.Jallikattu
{    

    public class SpeedBoost : PowerUp
    {
        public static bool onBoostMode;

        public float speedIncrease = 5f;
        public float duration = 3f;

        public override void PowerUpAction(BullController bull)
        {
            onBoostMode = true;
            Debug.Log("Picked SpeedUp");
            bull.OnSpeedupPowerup(speedIncrease, duration);
        }

    }
}
