using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AirplaneViewController : MonoBehaviour {
	public static AirplaneViewController airplaneViewCtrl = null;

	// Panels
	public GameObject addAirplanePanel;
	public GameObject showAirplanesPanel;

	// Airplanes
	// Use this for initialization
	void Start () {
		airplaneViewCtrl = new AirplaneViewController ();
		AirplaneController.airplaneCtrl = new AirplaneController ();
		refreshAirplanesTable ();
	}
	
	public void insertAirplanes(string modelName, string waypoints) {
		AirplaneController.airplaneCtrl.insertAirplane (modelName, waypoints);
	}

	public void deleteAirplane() {
		Transform button = EventSystem.current.currentSelectedGameObject.transform;
		Transform parent = button.parent;
		int id = int.Parse(parent.Find ("Id").GetComponent<Text> ().text);
		AirplaneController.airplaneCtrl.deleteAirplaneWithId (id);
		Destroy (parent.gameObject);
	}

	public void refreshAirplanesTable () {
		// Communicates with the showAirplanesView and invokes a function to refresh the table by inserting the new airplane details
		ArrayList airplanes = AirplaneController.airplaneCtrl.getAirplanes();
		DataController.dataCtrl.airplanes = airplanes;
		showAirplanesPanel.GetComponent<ShowAirplanesView> ().removeAirplanes ();
		showAirplanesPanel.GetComponent<ShowAirplanesView> ().populateAirplanes(airplanes);
		
	}
}
