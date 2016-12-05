using UnityEngine;
using System.Collections;

public class LookAtFirstWaypoint : MonoBehaviour {

	private AircraftMovement scriptAircraftMovement;
	private ArrayList childrenTranformCopy;

	private Transform airplane;

	public void Start () {
		childrenTranformCopy = new ArrayList ();

		airplane = transform.parent.Find ("MyAirplane");
		scriptAircraftMovement = airplane.GetComponent<AircraftMovement> ();
	}

	void Update () {
		for (int i = 0; i < transform.childCount; ++i) {
			childrenTranformCopy.Add(transform.GetChild (i).position);
		}

		transform.position = airplane.position;


		for (int i = 0; i < transform.childCount; ++i) {
			transform.GetChild (i).position = (Vector3) childrenTranformCopy [i];
		}
		childrenTranformCopy.Clear ();


		transform.LookAt (scriptAircraftMovement.getCurrentTarget ());
	}
	

}
