using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AircraftDetector: MonoBehaviour {

	private bool longArea = true;
	private Text infoText;
	private AudioSource sourceShortConflictAlarm;

	private GameObject myAirplane; 
	void Awake () {
		sourceShortConflictAlarm = GetComponent<AudioSource> ();
	}

	void Start() {
		infoText = GameObject.Find ("textInfo").GetComponent<Text> ();
		myAirplane = transform.parent.parent.gameObject;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Airplane" && other.gameObject.GetInstanceID() != myAirplane.GetInstanceID()) {
			if (this.gameObject.name == "ShortAreaDetector") {
				longArea = false;
				Debug.Log (other.gameObject.name);
				other.gameObject.GetComponent<Renderer> ().material.color = Color.magenta;
				transform.parent.parent.gameObject.GetComponent<Renderer> ().material.color = Color.magenta;
				infoText.text += "Short Conflict with: " + other.gameObject.name + "\n";
				sourceShortConflictAlarm.Play ();
			
			}
			else if (this.gameObject.name == "LongAreaDetector" && longArea) {
				other.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
				transform.parent.parent.gameObject.GetComponent<Renderer> ().material.color = Color.blue;

				infoText.text += "Long Conflict with: " + other.gameObject.name + "\n";

			}
		}
	}
		
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Airplane" && other.gameObject.GetInstanceID() != myAirplane.GetInstanceID()) {
			if (this.gameObject.name == "ShortAreaDetector") {
				longArea = true;
				other.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
				transform.parent.parent.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
				sourceShortConflictAlarm.Stop ();

			}
			else if (this.gameObject.name == "LongAreaDetector") {
				other.gameObject.GetComponent<Renderer> ().material.color = Color.white;
				transform.parent.parent.gameObject.GetComponent<Renderer> ().material.color = Color.white;

			}
		}
	}
		
}
