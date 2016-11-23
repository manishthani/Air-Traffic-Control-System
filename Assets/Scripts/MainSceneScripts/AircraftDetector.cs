using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AircraftDetector: MonoBehaviour {

	private bool longArea = true;

	private GameObject myAirplane; 

	void Awake() {
		myAirplane = transform.parent.parent.gameObject;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Airplane" && other.gameObject.GetInstanceID() != myAirplane.GetInstanceID()) {
			if (this.gameObject.name == "ShortAreaDetector") {
				longArea = false;
				other.gameObject.GetComponent<Renderer> ().material.color = Color.red;
				transform.parent.parent.gameObject.GetComponent<Renderer> ().material.color = Color.red;

				// Show collision in ScrollView 
				UIController.UICtrl.addCollisionInfo("Short Conflict with: " + other.gameObject.name);

				// Play alert sound
				AudioController.audioCtrl.PlayAudioSource ();
							
			}
			else if (this.gameObject.name == "LongAreaDetector" && longArea) {
				other.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
				transform.parent.parent.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;

				UIController.UICtrl.addCollisionInfo("Long Conflict with: " + other.gameObject.name);
			}
		}
	}
		
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Airplane" && other.gameObject.GetInstanceID() != myAirplane.GetInstanceID()) {
			if (this.gameObject.name == "ShortAreaDetector") {
				longArea = true;
				other.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
				transform.parent.parent.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;

				//Stop alert sound
				AudioController.audioCtrl.StopAudioSource ();

			}
			else if (this.gameObject.name == "LongAreaDetector") {
				other.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
				transform.parent.parent.gameObject.GetComponent<Renderer> ().material.color = Color.blue;

			}
		}
	}
		
}
