﻿using UnityEngine;
using System.Collections;

public class LookAtFirstTarget : MonoBehaviour {

	public GameObject myAirplane;
	private AircraftMovement scriptAircraftMovement;
	// Use this for initialization
	void Start () {
		scriptAircraftMovement = myAirplane.GetComponent<AircraftMovement> ();
		this.transform.LookAt(scriptAircraftMovement.getCurrentTarget ().position);

	}
	

}
