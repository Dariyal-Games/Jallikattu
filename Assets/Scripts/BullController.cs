using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullController : MonoBehaviour
{
    public Transform attachPoint;
    private AttackerController attacker;

    void Start()
    {
        if (attachPoint == null) throw new System.Exception("Attach Point not set.");
    }

    public void SetAttacker(AttackerController attacker)
    {
        this.attacker = attacker;
    }

    public AttackerController GetAttacker()
    {
        return attacker;
    }
}
