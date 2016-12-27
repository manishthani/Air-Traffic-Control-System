using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIAirplaneDetails : MonoBehaviour {
	// TODO: No hace falta que knots se llame en Update!

	public GameObject airplane;
	private AircraftMovement airplaneScript;
	void Start() {
		airplaneScript = airplane.GetComponent<AircraftMovement> ();
	}

	// Update is called once per frame
	void Update () {
		if (airplaneScript != null) {
			foreach (Transform t in transform) {
				if (t.name == Constants.TEXTALTITUDE) {
					t.gameObject.GetComponent<Text> ().text = "Height: " + (int)(airplane.transform.position.y * Constants.FEETTOMILE) + " feets";
				} else if (t.name == Constants.TEXTSPEED) {
					t.gameObject.GetComponent<Text> ().text = "Speed: " + airplaneScript.knots + " knots";
				}
			} 
		}
	}
}
