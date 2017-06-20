using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{

    public abstract void PowerUpAction(BullController bull);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PowerUpAction(other.gameObject.GetComponent<BullController>());
        }
    }
}
