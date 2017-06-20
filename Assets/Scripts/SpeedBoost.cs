using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : PowerUp
{
    public float speedIncrease = 5f;
    public float duration = 3f;

    public override void PowerUpAction(BullController bull)
    {
        Debug.Log("Picked SpeedUp");
        bull.IncreaseSpeed(speedIncrease, duration);
    }

}
