using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FuturePosition : MonoBehaviour {

	private float knots;
	private float secondsPerHour = 3600.0f;
	private float speed;
	private Transform nextTarget;
	private AircraftMovement aircraftMovementScript;


	void OnTriggerEnter(Collider other) {
		
		if (other.gameObject.name == this.gameObject.name) {
			UIController.UICtrl.showWarningPanel ();
			// Collision
			switch (other.gameObject.name) {
			case "1":
				Debug.Log (this.gameObject.name + " AND " + other.gameObject.name + " will collide in 12.5 seconds" );
				break;

			case "2":
				Debug.Log (this.gameObject.name + " AND " + other.gameObject.name + " will collide in 25 seconds" );
				break;

			case "3":
				Debug.Log (this.gameObject.name + " AND " + other.gameObject.name + " will collide in 37.5 seconds" );
				break;

			case "4":
				Debug.Log (this.gameObject.name + " AND " + other.gameObject.name + " will collide in 50 seconds" );
				break;
			case "5":
				Debug.Log (this.gameObject.name + " AND " + other.gameObject.name + " will collide in 50 seconds" );
				break;

			}
		}
	}

	void Awake (){
		float distance = 1.0f;
		if ( DataController.dataCtrl != null) {
			distance = DataController.dataCtrl.currentDistance;
		}

		float positionNumber = float.Parse (gameObject.name);
		transform.Translate (new Vector3 (0.0f, 0.0f, distance * positionNumber));
	}

	void Start () {
		// Script
		GameObject myAirplane = transform.parent.parent.FindChild("MyAirplane").gameObject;
		aircraftMovementScript = myAirplane.GetComponent<AircraftMovement> ();
		knots = aircraftMovementScript.knots;
		nextTarget = aircraftMovementScript.getCurrentTarget ();
		speed = knots / secondsPerHour;
	}
		
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, nextTarget.position, speed * Time.deltaTime);
		// Make cylinder always look at the target beacon
		if (transform.position == nextTarget.position) {
			if (aircraftMovementScript.existNextFutureTarget()) {
				nextTarget = aircraftMovementScript.getNextFutureTarget ();
			}
		}
	}
}
