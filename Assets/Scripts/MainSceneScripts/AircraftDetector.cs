using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AircraftDetector: MonoBehaviour {

	private bool longArea = true;

	private GameObject myAirplane; 

	void Awake() {
		myAirplane = transform.parent.parent.gameObject;
	}

	void Start() {

		myAirplane.GetComponent<AircraftMovement> ().knots = DataController.dataCtrl.airplaneSpeed;

		SphereCollider collider = gameObject.GetComponent<SphereCollider> ();
		if (gameObject.name == "LongAreaDetector") {
			collider.radius = DataController.dataCtrl.longAreaDetectorRadius;
		} else if (gameObject.name == "ShortAreaDetector") {
			collider.radius = DataController.dataCtrl.shortAreaDetectorRadius;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Airplane" && other.gameObject.GetInstanceID() != myAirplane.GetInstanceID()) {
			if (this.gameObject.name == "ShortAreaDetector") {
				longArea = false;
				other.gameObject.GetComponent<Renderer> ().material.color = Color.red;
				transform.parent.parent.gameObject.GetComponent<Renderer> ().material.color = Color.red;

				// Play alert sound
				AudioController.audioCtrl.PlayAudioSource ();
							
			}
			else if (this.gameObject.name == "LongAreaDetector" && longArea) {
				other.gameObject.GetComponent<Renderer> ().material.color = new Color (1, 0.60f, 0, 1);
				transform.parent.parent.gameObject.GetComponent<Renderer> ().material.color = new Color (1, 0.60f, 0, 1);

				UIController.UICtrl.addCollisionInfo("Long Conflict with: " + other.transform.Find("Canvas").Find("textAirplaneModel").GetComponent<Text>().text);
			}
		}
	}
		
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Airplane" && other.gameObject.GetInstanceID() != myAirplane.GetInstanceID()) {
			if (this.gameObject.name == "ShortAreaDetector") {
				longArea = true;
				other.gameObject.GetComponent<Renderer> ().material.color = new Color (1, 0.60f, 0, 1);
				transform.parent.parent.gameObject.GetComponent<Renderer> ().material.color = new Color (1, 0.60f, 0, 1);

				//Stop alert sound
				AudioController.audioCtrl.StopAudioSource ();
				UIController.UICtrl.hideWarningPanel ();


			}
			else if (this.gameObject.name == "LongAreaDetector") {
				other.gameObject.GetComponent<Renderer> ().material.color = Color.green;
				transform.parent.parent.gameObject.GetComponent<Renderer> ().material.color = Color.green;

			}
		}
	}
		
}
