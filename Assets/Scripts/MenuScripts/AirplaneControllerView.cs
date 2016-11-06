using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class AirplaneControllerView : MonoBehaviour {


	// UI Elements related to Add airplane
	public GameObject inputModelName;

	public GameObject inputXWaypoints;
	public GameObject inputYWaypoints;
	public GameObject inputZWaypoints;

	public GameObject tableWaypoints;
	public GameObject waypointRowView; 

	// UI Scripts 
	private PopulateTables populateCoordinates; 

	// Data
	private string coordinates;
	private string modelName;

	void Start() {
		LocalDataController.localDataCtrl = new LocalDataController ();
		populateCoordinates = new PopulateTables();
	}

	public void addAirplaneWaypointsEvent() {
		// Read data from inputs
		modelName = inputModelName.GetComponent<InputField>().text;

		string waypointXCoord = inputXWaypoints.GetComponent<InputField> ().text;
		string waypointYCoord = inputYWaypoints.GetComponent<InputField> ().text;
		string waypointZCoord = inputZWaypoints.GetComponent<InputField> ().text;

		//Clear Inputs
		inputXWaypoints.GetComponent<InputField> ().text = string.Empty;
		inputYWaypoints.GetComponent<InputField> ().text = string.Empty;
		inputZWaypoints.GetComponent<InputField> ().text = string.Empty;

		// Populate List
		ArrayList rowData = new ArrayList ();
		rowData.Add (waypointXCoord);
		rowData.Add (waypointYCoord);
		rowData.Add (waypointZCoord);

		populateCoordinates.addRowToTable (tableWaypoints, waypointRowView, rowData);

		coordinates += waypointXCoord + "," + waypointYCoord + "," + waypointZCoord + ";";
	}

	public void addAirplaneEvent() {
		int id = 49;
		LocalDataController.localDataCtrl.Insert (id, modelName, coordinates);
	}
}
