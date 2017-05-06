using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour {

	public GameObject Bull;
	public Transform personToAttach;



	void Awake()
	{
		
		//bullposi = GetComponent<BullPosition> ();

	}

   
    public void Start()
    {
		//PosPlayer = GameObject.FindGameObjectWithTag("Player").transform;

    }
    public void Update()
    {

    }

    void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "Player")
        {
			//transform.rotation=Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(PosPlayer.position-transform.position,CrowdRotateSpeed*Time.deltaTime));
			 //transform.position += transform.position * CrowdMoveSpeed*Time.deltaTime;
			//OnTriggerEnter()

			//transform.position = Bull.transform.position;
			var attachPoint = other.gameObject.GetComponent<BullController>().attachPoint;
			var pattachPoint = personToAttach.GetCo
	    }
	}
		

	void AttachToPoint()
	{
		
	}

}
