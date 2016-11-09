using UnityEngine;
using System.Collections;

public class AircraftMovement : MonoBehaviour {

	//public int frameRate = 2;
	public float knots = 600.0f;

	private ArrayList targets;

	// Begins at 1 since 0 is the initial position of aircraft
	private int index = 1;
	private const float secondsPerHour = 3600.0f;

		
	public void incrementIndex() {
		index = index + 1;
	}

	public Transform getCurrentTarget () {
		return (Transform) targets [index];
	}
	public Transform getNextFutureTarget() {
		return (Transform) targets [index + 1];
	}

	public bool existNextFutureTarget() {
		return index + 1 < targets.Count;
	}

	public bool existMoreTargets () {
		return index < targets.Count;
	}
		

	void Start() {
		//QualitySettings.vSyncCount = 0;
		//Application.targetFrameRate = frameRate;
		targets = new ArrayList();
		// Add Initial position
		targets.Add (transform.position);
		Transform waypoints = transform.parent.FindChild ("Waypoints").transform;

		for (int i = 0; i < waypoints.childCount; ++i) {
			targets.Add (waypoints.GetChild (i));
		}
		Debug.Log ("START");
	}

	// Update is called once per frame
	void Update () {

		float step = knots / secondsPerHour * Time.deltaTime;
		if (transform.position == ((Transform) targets [index]).position && existNextFutureTarget()) {
			index++;
		}
		if (existMoreTargets()) {
			transform.position = Vector3.MoveTowards (transform.position, ((Transform)targets [index]).position, step);
		}

		/*

this.gameObject.transform.LookAt (targets [index].position);
			// Make cylinder always look at the target beacon
			Vector3 relativePos = targets [index].position - transform.position;
			if (relativePos != Vector3.zero) {
				transform.rotation = Quaternion.LookRotation (relativePos, Vector3.up);
			}
		*/

		/*if (Input.GetKey (KeyCode.LeftArrow)) {
			this.gameObject.transform.Translate (knots/secondsPerHour * Time.deltaTime * Vector3.left);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			this.gameObject.transform.Translate (knots/secondsPerHour * Time.deltaTime * Vector3.right);
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			this.gameObject.transform.Translate (knots/secondsPerHour * Time.deltaTime * Vector3.up);
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			this.gameObject.transform.Translate (knots/secondsPerHour * Time.deltaTime * Vector3.down);
		}*/

		/*this.gameObject.transform.LookAt (targets [index].position);
		// Make cylinder always look at the target beacon
		Vector3 relativePos = targets [index].position - transform.position;
		if (relativePos != Vector3.zero) {
			transform.rotation = Quaternion.LookRotation (relativePos, Vector3.up);
		}*/

	}
}
