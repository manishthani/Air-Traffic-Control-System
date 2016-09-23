using UnityEngine;
using System.Collections;

public class AircraftMovement : MonoBehaviour {

	//public int frameRate = 2;
	public float knots = 600.0f;

	public Transform[] targets;
	public Transform futurePositions; 


	private int index = 0;
	private const float secondsPerHour = 3600.0f;

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "Beacon") {
			index++;
			if (index < targets.Length) {
				this.gameObject.transform.LookAt (targets [index].position);
			}
		} 
		//Destroy (gameObject);
		//Destroy (col.gameObject);
	}
	// Use this for initialization
	void Start() {
		//QualitySettings.vSyncCount = 0;
		//Application.targetFrameRate = frameRate;
	}

	public void incrementIndex() {
		index = index + 1;
	}
	// Update is called once per frame
	void Update () {
		//this.gameObject.transform.Translate (speed/2 * Time.deltaTime * Vector3.forward);
		float step = knots / secondsPerHour * Time.deltaTime;
		if (index < targets.Length) {
			transform.position = Vector3.MoveTowards (transform.position, targets [index].position, step);

			// Make cylinder always look at the target beacon
			Vector3 relativePos = targets [index].position - transform.position;
			transform.rotation = Quaternion.LookRotation (relativePos, Vector3.up);

			if (transform.position == targets [index].position) {
				this.gameObject.transform.Rotate( new Vector3( gameObject.transform.rotation.x,Vector3.Angle(futurePositions.position, targets[index].position), gameObject.transform.rotation.z));
			}
		}

		/*if (this.transform.position.y < 1) 
			this.transform.Translate (speed/2 * Time.deltaTime * Vector3.up);*/
		
		if (Input.GetKey (KeyCode.LeftArrow)) {
			this.gameObject.transform.Translate (knots/secondsPerHour * Time.deltaTime * Vector3.left);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			this.gameObject.transform.Translate (knots/secondsPerHour * Time.deltaTime * Vector3.right);
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			this.gameObject.transform.Translate (knots/secondsPerHour * Time.deltaTime * Vector3.up);
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			this.gameObject.transform.Translate (knots/secondsPerHour * Time.deltaTime * Vector3.down);
		}




	}
	/*void OnMouseDown (){
		Debug.Log ("Clicked!");
		myCamera.SetActive (true);
		camera2D.SetActive (false);
	}*/
}
