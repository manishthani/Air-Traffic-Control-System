using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AircraftDetector: MonoBehaviour {

	private bool longArea = true;
	private Text infoText;

	void Start() {
		infoText = GameObject.Find ("textInfo").GetComponent<Text> ();
	}

	void OnTriggerEnter(Collider other) {
		
		if (other.gameObject.tag == "CPUAirplane") {
			if (this.gameObject.name == "ShortAreaDetector") {
				longArea = false;
				other.gameObject.GetComponent<Renderer> ().material.color = Color.magenta;
				infoText.text += "Short Conflict with: " + other.gameObject.name + "\n";
			}
			else if (this.gameObject.name == "LongAreaDetector" && longArea) {
				other.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
				infoText.text += "Long Conflict with: " + other.gameObject.name + "\n";

			}
		}
	}
		
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "CPUAirplane") {
			if (this.gameObject.name == "ShortAreaDetector") {
				longArea = true;
				other.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			}
			else if (this.gameObject.name == "LongAreaDetector") {
				other.gameObject.GetComponent<Renderer> ().material.color = Color.white;
			}
		}
	}
		
}
