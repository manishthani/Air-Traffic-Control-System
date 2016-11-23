using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class InsertAirplaneView : MonoBehaviour {


	// UI Elements related to Add airplane
	public GameObject inputModelName;

	public GameObject inputXWaypoints;
	public GameObject inputYWaypoints;
	public GameObject inputZWaypoints;

	public GameObject tableWaypoints;
	public GameObject waypointRowView; 

	public GameObject trajectory;

	// Delete rows elements
	public GameObject deletePanel;


	// UI Scripts 
	private PopulateTables populateCoordinates; 

	// Data
	private int id = -1;
	private string modelName;
	private int childCount;
	void Start() {
		childCount = tableWaypoints.transform.childCount;
		populateCoordinates = new PopulateTables();
	}

	void Update() {
		if (tableWaypoints.transform.childCount != childCount) {
			childCount = tableWaypoints.transform.childCount;
			refreshWaypointsTable ();
		}
	}

	public void addAirplaneWaypointsEvent() {
		float waypointX = float.Parse(inputXWaypoints.GetComponent<InputField> ().text);
		float waypointY = float.Parse(inputYWaypoints.GetComponent<InputField> ().text);
		float waypointZ = float.Parse(inputZWaypoints.GetComponent<InputField> ().text);

		Debug.Log (waypointX.ToString() + " , " + waypointY.ToString() + " , " + waypointZ.ToString() );

		//Clear Inputs
		inputXWaypoints.GetComponent<InputField> ().text = string.Empty;
		inputYWaypoints.GetComponent<InputField> ().text = string.Empty;
		inputZWaypoints.GetComponent<InputField> ().text = string.Empty;

		// Add waypoint
		addWaypointsWithCoordinates (waypointX.ToString(), waypointY.ToString(), waypointZ.ToString());
	}

	public void insertAirplaneEvent() {
		// Read modelName from inputs
		modelName = inputModelName.GetComponent<InputField>().text;
		AirplaneViewController.airplaneViewCtrl.insertAirplanes (id, modelName, getCoordinatesFromRowViews ());
		clearAllFields ();
	}


	public void addWaypointsWithCoordinates (string waypointX, string waypointY, string waypointZ) {
		// Populate List
		ArrayList rowData = new ArrayList ();
		rowData.Add (waypointX);
		rowData.Add (waypointY);
		rowData.Add (waypointZ);

		GameObject rowView = populateCoordinates.addRowToTable (tableWaypoints, waypointRowView, rowData);

		AirplaneTrajectoriesView atvScript = trajectory.GetComponent<AirplaneTrajectoriesView> ();
		atvScript.clean ();
		atvScript.drawAirplane (id, getCoordinatesFromRowViews ());
	}

	public void fillAirplaneData (int id, string modelName, string waypoints) {
		populateCoordinates = new PopulateTables ();

		clearAllFields ();
		populateAllFields (id, modelName, waypoints);
	}


	private void populateAllFields (int airplaneId, string modelName, string waypoints) {

		// Fill Inputs
		id = airplaneId;
		// Model name
		inputModelName.GetComponent<InputField>().text = modelName;
		// Waypoints
		ArrayList waypointsArray = Utilities.parseToVector3 (waypoints);
		foreach (Vector3 waypoint in waypointsArray) {
			addWaypointsWithCoordinates (waypoint.x.ToString (), waypoint.y.ToString (), waypoint.z.ToString ());
		}

		AirplaneTrajectoriesView atvScript = trajectory.GetComponent<AirplaneTrajectoriesView> ();
		atvScript.clean ();
		atvScript.drawAirplane (id, getCoordinatesFromRowViews());
	}

	public void clearAllFields () {
		//Clear Inputs
		id = -1;
		// Model name
		inputModelName.GetComponent<InputField>().text = string.Empty;

		// Waypoint
		inputXWaypoints.GetComponent<InputField> ().text = string.Empty;
		inputYWaypoints.GetComponent<InputField> ().text = string.Empty;
		inputZWaypoints.GetComponent<InputField> ().text = string.Empty;

		// Clear Waypoints List
		populateCoordinates.removeRows(tableWaypoints);
	}

	// Delete waypoints functionality methods
	public void checkboxDeleteEvent () {
		bool enabledDeletePanel = false;
		for (int i = 0; i < tableWaypoints.transform.childCount; ++i) {
			Transform row = tableWaypoints.transform.GetChild (i);
			if (row.Find ("Checkbox").GetComponent<Toggle> ().isOn) {
				enabledDeletePanel = true;
				break;
			}
		}
		deletePanel.SetActive (enabledDeletePanel);
	}

	public void deleteButtonInDeletePanelEvent() {
		for (int i = 0; i < tableWaypoints.transform.childCount; ++i) {
			Transform row = tableWaypoints.transform.GetChild (i);
			Toggle checkbox = row.Find ("Checkbox").GetComponent<Toggle> ();

			if (checkbox.isOn) {
				Destroy (row.gameObject);	
			}
		}
		deletePanel.SetActive (false);
	}
		

	public void cancelButtonInDeletePanelEvent() {
		for (int i = 0; i < tableWaypoints.transform.childCount; ++i) {
			Toggle checkbox = tableWaypoints.transform.GetChild (i).Find ("Checkbox").GetComponent<Toggle> ();
			if (checkbox.isOn) {
				checkbox.isOn = false;
			}
		}
		deletePanel.SetActive (false);
	}

	public void refreshWaypointsTable() {
		string coordinates = getCoordinatesFromRowViews ();
		// Clear Waypoints List																																																																																													ºººººººº
		populateCoordinates.removeRows(tableWaypoints);

		ArrayList waypointsArray = Utilities.parseToVector3 (coordinates);
		foreach (Vector3 waypoint in waypointsArray) {
			addWaypointsWithCoordinates (waypoint.x.ToString (), waypoint.y.ToString (), waypoint.z.ToString ());
		}

		// Refresh Trajectory
		AirplaneTrajectoriesView atvScript = trajectory.GetComponent<AirplaneTrajectoriesView> ();
		atvScript.clean ();
		atvScript.drawAirplane (id, coordinates);
	}

	private string getCoordinatesFromRowViews () {
		string coordinates = string.Empty;
		for (int i = 1; i < tableWaypoints.transform.childCount; ++i) {
			Transform row = tableWaypoints.transform.GetChild(i);
			Text[] rowText = row.GetComponentsInChildren<Text> ();
			coordinates += rowText [0].text + "," + rowText[1].text + "," + rowText[2].text + ";";
		}
		return coordinates;
	}
}
