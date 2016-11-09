using UnityEngine;
using System.Collections;

public class LookAtFirstWaypoint : MonoBehaviour {

	private AircraftMovement scriptAircraftMovement;
	// Use this for initialization
	void Start () {
		GameObject myAirplane = transform.parent.FindChild ("MyAirplane").gameObject;
		scriptAircraftMovement = myAirplane.GetComponent<AircraftMovement> ();
		this.transform.LookAt(scriptAircraftMovement.getCurrentTarget ().position);

	}
	

}
