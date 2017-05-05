using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Stats : MonoBehaviour {

	public Primary PrimaryStats;

	public float Accelertion {
		get { return ((PrimaryStats.Strength*.75f) + (PrimaryStats.Stamina*.25f)) * UnityConversionFactors.Acceleration; }
	}
	public float Deceleration {
		get{ return ((PrimaryStats.Strength*.25f) + (PrimaryStats.Stamina*.75f))*UnityConversionFactors.Deceleration; }
	}
	public float TurnRate {
		get{ return PrimaryStats.Agility * UnityConversionFactors.TurnRate; }
	}
	public float MinSpeed {
		get{ return PrimaryStats.Speed * UnityConversionFactors.Speed; }
	}
	public float MaxSpeed {
		get{ return PrimaryStats.Speed * UnityConversionFactors.Speed; }
	}
	public float Shrug {
		get{ return PrimaryStats.Strength * UnityConversionFactors.Shrug; }
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	[Serializable]
	public class Primary
	{
		public float Strength{ get; set;}
		public float Stamina{ get; set;}
		public float Agility{ get; set; }
		public float Speed{ get; set; }

	}
}
