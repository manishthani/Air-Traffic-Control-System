using UnityEngine;
using System.Collections;

public class futurePositionCylinder : MonoBehaviour {
	public GameObject airplane; 
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Beacon") {
			Debug.Log ("Collisiisio");		
			airplane.GetComponent<AircraftMovement> ().incrementIndex ();
			//float scaleZ = gameObject.transform.localScale.z;
			//gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y* 0.2f, scaleZ );


		}
	
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
