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

	void OnMouseDown() {
		// To avoid clicks pass through GUI controls
		if (!EventSystem.current.IsPointerOverGameObject ()){
			camera3D.SetActive (true);
			camera2D.SetActive (false);	
		}
	}
}
