using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dariyal.Jallikattu
{
    public class SpeedBoost : PowerUp
    {
        public float speedIncrease = 5f;
        public float duration = 3f;

        public override void PowerUpAction(BullController bull)
        {
            Debug.Log("Picked SpeedUp");
            bull.OnSpeedupPowerup(speedIncrease, duration);
        }

    }
}
