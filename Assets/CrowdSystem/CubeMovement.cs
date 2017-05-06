﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour {
public float speed;
	void Update()
	{
		if (Input.GetKey (KeyCode.W))
			transform.Translate (Vector3.forward * Time.deltaTime * speed);
		if (Input.GetKey (KeyCode.S))
			transform.Translate (-1* Vector3.forward * Time.deltaTime * speed);
		if (Input.GetKey (KeyCode.A))
			transform.Rotate (0, -1, 0);
		if (Input.GetKey (KeyCode.D))
			transform.Rotate (0, 1, 0);
}
}
