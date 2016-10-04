using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FuturePosition : MonoBehaviour {
	public GameObject aircraft;

	private float knots;
	private float secondsPerHour = 3600.0f;
	private float speed;
	private Transform nextTarget;
	private AircraftMovement aircraftMovementScript;

	// Use this for initialization


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == this.gameObject.name) {
			// Collision
			switch (other.gameObject.name) {
			case "Position1":
				Debug.Log (this.gameObject.name + " AND " + other.gameObject.name + " will collide in 12.5 seconds" );
				break;

			case "Position2":
				Debug.Log (this.gameObject.name + " AND " + other.gameObject.name + " will collide in 25 seconds" );
				break;

			case "Position3":
				Debug.Log (this.gameObject.name + " AND " + other.gameObject.name + " will collide in 37.5 seconds" );
				break;

			case "Position4":
				Debug.Log (this.gameObject.name + " AND " + other.gameObject.name + " will collide in 50 seconds" );
				break;

			}
		}
	}

	void Start () {
		// Script
		aircraftMovementScript = aircraft.GetComponent<AircraftMovement> ();
		knots = aircraftMovementScript.knots;
		nextTarget = aircraftMovementScript.getCurrentTarget ();
		speed = knots / secondsPerHour;


	}

	// Update is called once per frame
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
