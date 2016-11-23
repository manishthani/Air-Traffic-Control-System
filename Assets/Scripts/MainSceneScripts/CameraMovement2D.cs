using UnityEngine;
using System.Collections;

public class CameraMovement2D : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.activeSelf ) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.Translate (Vector3.left * 2.0f);
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				transform.Translate (Vector3.right * 2.0f);
			} else if (Input.GetKey (KeyCode.UpArrow)) {
				transform.Translate (Vector3.up * 2.0f);
			} else if (Input.GetKey (KeyCode.DownArrow)) {
				transform.Translate (Vector3.down * 2.0f);
			} else if (Input.GetKey (KeyCode.Z)) {
				if (transform.GetComponent<Camera> ().orthographicSize > 2.0) {
					transform.GetComponent<Camera> ().orthographicSize -= 1.0f;
				}	
			} else if (Input.GetKey (KeyCode.X)) {
				if (transform.GetComponent<Camera> ().orthographicSize < 150.0) {
					transform.GetComponent<Camera> ().orthographicSize += 1.0f;
				}
			}
		}
	}
}
