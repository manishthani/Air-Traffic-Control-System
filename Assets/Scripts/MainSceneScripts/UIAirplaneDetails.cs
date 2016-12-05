using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIAirplaneDetails : MonoBehaviour {

	public GameObject airplane;

	// Update is called once per frame
	void Update () {
		foreach (Transform t in this.gameObject.transform){
			if (t.gameObject.name == "textAltitude") {
				t.gameObject.GetComponent<Text> ().text = "Height: " + airplane.transform.position.y;
			} else if (t.gameObject.name == "textSpeed") {
				t.gameObject.GetComponent<Text> ().text = "Speed: " + airplane.GetComponent<AircraftMovement>().knots +  " knots";
			}
		} 
	}
}
