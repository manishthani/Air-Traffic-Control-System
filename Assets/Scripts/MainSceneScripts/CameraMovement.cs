using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour {

	private GameObject camera2D;
	private GameObject camera3D;

	// Use this for initialization
	void Start () {
		camera2D = GameObject.FindWithTag ("2DCamera");
		camera3D = transform.parent.parent.Find ("3DCamera").gameObject;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			camera3D.SetActive (false);
			camera2D.SetActive (true);
		}
	}

	public void manageCamera3DControlsOfNextWaypoint( Transform waypoint) {
		// Aircraft movement controls
		if (Input.GetKey (KeyCode.UpArrow)) {
			waypoint.Translate (Vector3.up,Space.Self);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			waypoint.Translate (Vector3.down,Space.Self);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			waypoint.Translate (Vector3.left,Space.Self);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			waypoint.Translate (Vector3.right,Space.Self);
		}
		if (Input.GetKey (KeyCode.Z)) {
			waypoint.Translate (Vector3.forward, Space.Self);
		}
		if (Input.GetKey (KeyCode.X)) {
			waypoint.Translate (Vector3.back, Space.Self);
		}
	}

	void OnMouseDown() {
		// To avoid clicks pass through GUI controls
		if (!EventSystem.current.IsPointerOverGameObject ()){
			camera3D.SetActive (true);
			camera2D.SetActive (false);	
		}
	}
}
