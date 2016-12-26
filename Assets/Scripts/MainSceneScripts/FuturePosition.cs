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
			
			float spaceCollision = int.Parse (other.gameObject.name) * DataController.dataCtrl.currentDistance;
			float speedCollision = aircraftMovementScript.realSpeed;
			float timeForCollision = (spaceCollision / speedCollision);

			Transform atc1 = transform.parent.parent;
			string airplaneName1 = atc1.Find ("MyAirplane").Find ("Canvas").Find ("textAirplaneModel").GetComponent<Text> ().text;

			Transform atc2 = other.transform.parent.parent;
			string airplaneName2 = atc2.Find ("MyAirplane").Find ("Canvas").Find ("textAirplaneModel").GetComponent<Text> ().text;

			// Collision
			GameMaster.gm.showWarningPanel ();
			GameMaster.gm.addInfoToWarningPanel (airplaneName1,  airplaneName2, timeForCollision);
		}
	}
}
