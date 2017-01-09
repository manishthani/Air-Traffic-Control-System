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
		AirplaneDataController.airplaneDataCtrl = new AirplaneDataController ();
		showAirplanesPanel.GetComponent<ShowAirplanesView> ().refreshAirplanesTable ();
		showAirplanesPanel.GetComponent<ShowAirplanesView> ();
	}
	
	public void insertAirplanes(int id, string modelName, string waypoints) {
		if (id == -1 ) {
			Debug.Log ("Adding!");
			AirplaneDataController.airplaneDataCtrl.insertAirplane (modelName, waypoints);
		} else {
			Debug.Log ("Updating!");
			AirplaneDataController.airplaneDataCtrl.updateAirplane (id, modelName, waypoints);
		}
	}

	public void updateAirplane(int id, string modelName, string waypoints) {
		AirplaneDataController.airplaneDataCtrl.updateAirplane (id, modelName, waypoints);
	}

	public void fillAirplaneData() {
		// Get Row Transform
		Transform button = EventSystem.current.currentSelectedGameObject.transform;
		Transform parent = button.parent;

		// Get data from row
		int id = int.Parse(parent.Find (Constants.ID).GetComponent<Text> ().text);
		string modelName = parent.Find (Constants.MODELNAME).GetComponent<Text>().text;
		string waypoints = parent.Find (Constants.WAYPOINTS).GetComponent<Text> ().text;

		// Send this data to the corresponding view as it is encharged of handling it
		insertAirplanePanel.GetComponent<InsertAirplaneView> ().fillAirplaneData (id, modelName, waypoints);

	}

	public void clearAirplaneFields () {
		insertAirplanePanel.GetComponent<InsertAirplaneView> ().clearAllFields();
	}

	public ArrayList getAirplanes () {
		// TODO: dataCtrl can be updated with other function calls, do that
		// Communicates with the showAirplanesView and invokes a function to refresh the table by inserting the new airplane details
		ArrayList airplanes = AirplaneDataController.airplaneDataCtrl.getAirplanes();
		DataController.dataCtrl.airplanes = airplanes;
		return airplanes;
	}
}
