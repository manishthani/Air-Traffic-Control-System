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
				UIController.UICtrl.addWarningPanelInfo( transform.parent.parent.gameObject.name + " AND " + other.transform.parent.parent.gameObject.name + " will collide in 12.5 seconds" );
				break;

			case "2":
				UIController.UICtrl.addWarningPanelInfo( transform.parent.parent.gameObject.name + " AND " + other.transform.parent.parent.gameObject.name + " will collide in 25 seconds" );
				break;

			case "3":
				UIController.UICtrl.addWarningPanelInfo( transform.parent.parent.gameObject.name + " AND " + other.transform.parent.parent.gameObject.name + " will collide in 37.5 seconds" );
				break;

			case "4":
				UIController.UICtrl.addWarningPanelInfo( transform.parent.parent.gameObject.name + " AND " + other.transform.parent.parent.gameObject.name + " will collide in 50 seconds" );
				break;
			case "5":
				UIController.UICtrl.addWarningPanelInfo( transform.parent.parent.gameObject.name + " AND " + other.transform.parent.parent.gameObject.name + " will collide in 62.5 seconds" );
				break;

			}
		}
	}

	void Awake (){
	}

	void Start () {
		float distance = DataController.dataCtrl.currentDistance;


		float positionNumber = float.Parse (gameObject.name);
		transform.Translate (new Vector3 (0.0f, 0.0f, distance * positionNumber));
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
