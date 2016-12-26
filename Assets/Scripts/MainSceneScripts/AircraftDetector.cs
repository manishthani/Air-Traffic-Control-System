using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AircraftDetector: MonoBehaviour {

	private bool longArea = true;

	private GameObject myAirplane; 
	private Renderer myAirplaneRenderer;
	private string myAirplaneModelName;

	void Awake() {
		myAirplane = transform.parent.parent.gameObject;
		myAirplaneRenderer = myAirplane.GetComponent<Renderer> ();
		myAirplaneModelName = myAirplane.transform.Find ("Canvas").Find ("textAirplaneModel").GetComponent<Text> ().text;
	}

	void Start() {

		myAirplane.GetComponent<AircraftMovement> ().knots = DataController.dataCtrl.airplaneSpeed;

		SphereCollider collider = gameObject.GetComponent<SphereCollider> ();
		if (gameObject.name == Constants.LONGRANGEDETECTOR) {
			collider.radius = DataController.dataCtrl.longAreaDetectorRadius;
		} else if (gameObject.name == Constants.SHORTRANGEDETECTOR) {
			collider.radius = DataController.dataCtrl.shortAreaDetectorRadius;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Airplane" && other.gameObject.GetInstanceID() != myAirplane.GetInstanceID()) {
			Color color = new Color ();
			string otherName = other.transform.Find ("Canvas").Find ("textAirplaneModel").GetComponent<Text> ().text;
			if (gameObject.name == Constants.SHORTRANGEDETECTOR) {
				longArea = false;
				color = Color.red;
				// Play alert sound
				GameMaster.gm.playAlert ();
				GameMaster.gm.addInfoToConflictPanel ("Short Conflict between: " + myAirplaneModelName + " AND " + otherName);

			}
			else if (gameObject.name == Constants.LONGRANGEDETECTOR && longArea) {
				color = new Color (1, 0.60f, 0, 1);
				GameMaster.gm.addInfoToConflictPanel ("Long Conflict between: " + myAirplaneModelName + " AND " + otherName);
			}

			setCollidedAirplaneColor (color,myAirplaneRenderer,other.gameObject.GetComponent<Renderer> ());

			// Update Visualization Data Controlller
			VisualizationDataController.vdCtrl.totalConflicts++;
		}
	}
		
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Airplane" && other.gameObject.GetInstanceID() != myAirplane.GetInstanceID()) {
			Color color = new Color ();
			if (gameObject.name == Constants.SHORTRANGEDETECTOR) {
				longArea = true;
				color = new Color (1.0f, 0.60f, 0.0f, 1.0f);
				//Stop alert sound
				GameMaster.gm.stopAlert();
			}
			else if (gameObject.name == Constants.LONGRANGEDETECTOR) {
				color = Color.green;
			}
			setCollidedAirplaneColor (color,myAirplaneRenderer,other.gameObject.GetComponent<Renderer> ());
		}
	}

	private void setCollidedAirplaneColor (Color color, Renderer airplaneRenderer, Renderer otherRenderer) {
		otherRenderer.material.color = color;
		airplaneRenderer.material.color = color;
	}
}
