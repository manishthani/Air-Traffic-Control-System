using UnityEngine;
using System.Collections;

public class AircraftMovement : MonoBehaviour {

	//public int frameRate = 2;
	public float knots = 600.0f;

	public Transform[] targets;
	public Transform futurePositions; 


	private int index = 0;
	private const float secondsPerHour = 3600.0f;

		
	public void incrementIndex() {
		index = index + 1;
	}

	public Transform getCurrentTarget () {
		return targets [index];
	}
	public Transform getNextFutureTarget() {
		return targets [index + 1];
	}

	public bool existNextFutureTarget() {
		return index + 1 < targets.Length;
	}

	public bool existMoreTargets () {
		return index < targets.Length;
	}


	void OnTriggerEnter(Collider col) {
		Debug.Log ("Collided with " + col.gameObject.name);
	}

	void Start() {
		//QualitySettings.vSyncCount = 0;
		//Application.targetFrameRate = frameRate;
	}

	// Update is called once per frame
	void Update () {

		float step = knots / secondsPerHour * Time.deltaTime;
		if (transform.position == targets [index].position && existNextFutureTarget()) {
			index++;
		}
		if (existMoreTargets()) {
			transform.position = Vector3.MoveTowards (transform.position, targets [index].position, step);

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
