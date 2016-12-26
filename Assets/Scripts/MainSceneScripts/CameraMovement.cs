using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour {

	private GameObject camera2D;
	private GameObject camera3D;
	private GameObject futurePositions;

	public float speed = 0.05f;

	// Use this for initialization
	void Start () {
		camera2D = GameObject.FindWithTag ("2DCamera");
		camera3D = transform.parent.parent.Find ("3DCamera").gameObject;
		camera3D.SetActive (false);
		futurePositions = transform.parent.parent.parent.Find ("FuturePositions").gameObject;

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			camera3D.SetActive (false);
			camera2D.SetActive (true);
		}


	}

	public void manageCamera3DControlsOfNextWaypoint( GameObject airplane, Transform waypoint) {
		if (camera3D.activeSelf) {
			Vector3 direction = new Vector3 ();
			// Aircraft movement controls
			if (Input.GetKey (KeyCode.UpArrow)) {
				direction = Vector3.up;
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				direction = Vector3.down;
			}
			waypoint.Translate (direction * speed, Space.World);
			airplane.transform.Translate (direction * speed, Space.World);
			futurePositions.transform.Translate (direction * speed, Space.World);
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
