using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullController : MonoBehaviour 
{
	public Transform attachPoint;

    void Start()
    {
        if (attachPoint == null) throw new System.Exception("Attach Point not set.");
    }

}
