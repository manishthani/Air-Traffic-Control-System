using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {


	// Es necesario que la camara siga al avion? No seria mas logico que la camara este en un solo sitio y que vea los aviones moverse? 
	// Si es asi, como se haria para visualizarlo en 3D?
	private GameObject camera2D;
	private GameObject camera3D;


	// Use this for initialization
	void Start () {
		camera2D = GameObject.FindWithTag ("2DCamera");
		Debug.Log( "ajdfsñ" + transform.parent.parent.name);
		camera3D = transform.parent.parent.Find ("3DCamera").gameObject;
	}

	// Update is called once per frame
	void Update () {
		/*if (Input.GetMouseButtonDown (0)) {
			/*Ray ray = camera2D.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				if (hit.collider.gameObject.tag == "Radar") {
					camera3D.SetActive (true);
					camera2D.SetActive (false);
				}
			}
		}*/
		if (Input.GetKey (KeyCode.Escape)) {
			camera3D.SetActive (false);
			camera2D.SetActive (true);
		}

	}

	void OnMouseDown() {
		camera3D.SetActive (true);
		camera2D.SetActive (false);	
	}
}
