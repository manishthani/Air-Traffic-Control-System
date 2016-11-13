using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AirplaneViewController : MonoBehaviour {
	public static AirplaneViewController airplaneViewCtrl = null;

	// Panels
	public GameObject insertAirplanePanel;
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

		refreshAirplanesTable ();
	}

	public void fillAirplaneData() {
		// Get Row Transform
		Transform button = EventSystem.current.currentSelectedGameObject.transform;
		Transform parent = button.parent;

		// Get data from row
		int id = int.Parse(parent.Find ("Id").GetComponent<Text> ().text);
		string modelName = parent.Find ("ModelName").GetComponent<Text>().text;
		string waypoints = parent.Find ("Waypoints").GetComponent<Text> ().text;

		// Send this data to the corresponding view as it is encharged of handling it
		insertAirplanePanel.GetComponent<InsertAirplaneView> ().fillAirplaneData (id, modelName, waypoints);

	}

	public void clearAirplaneFields () {
		insertAirplanePanel.GetComponent<InsertAirplaneView> ().clearAllFields();
	}

	public void refreshAirplanesTable () {
		// Communicates with the showAirplanesView and invokes a function to refresh the table by inserting the new airplane details
		ArrayList airplanes = AirplaneController.airplaneCtrl.getAirplanes();
		DataController.dataCtrl.airplanes = airplanes;
		showAirplanesPanel.GetComponent<ShowAirplanesView> ().removeAirplanes ();
		showAirplanesPanel.GetComponent<ShowAirplanesView> ().populateAirplanes(airplanes);
		
	}
}
