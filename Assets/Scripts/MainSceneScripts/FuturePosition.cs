using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FuturePosition : MonoBehaviour {

	private Transform nextTarget;
	private AircraftMovement aircraftMovementScript;

	void Start () {
		float distance = DataController.dataCtrl.currentDistance;
		float positionNumber = float.Parse (gameObject.name);
		transform.Translate (new Vector3 (0.0f, 0.0f, distance * positionNumber));

		// Script
		GameObject myAirplane = transform.parent.parent.FindChild("MyAirplane").gameObject;
		aircraftMovementScript = myAirplane.GetComponent<AircraftMovement> ();
		nextTarget = aircraftMovementScript.getCurrentTarget ();
	}

	void Update () {

		float speed = aircraftMovementScript.currentSpeed;

		transform.position = Vector3.MoveTowards (transform.position, nextTarget.position, speed);
		// Make cylinder always look at the target beacon
		if (transform.position == nextTarget.position) {
			if (aircraftMovementScript.existNextFutureTarget()) {
				nextTarget = aircraftMovementScript.getNextFutureTarget ();
			}
		}
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.name == this.gameObject.name) {
			// Collision
			GameMaster.gm.showWarningPanel ();
			GameMaster.gm.addInfoToWarningPanel (transform.parent.parent.gameObject.name,  other.transform.parent.parent.gameObject.name, int.Parse(other.gameObject.name));
		
		}
	}
}
