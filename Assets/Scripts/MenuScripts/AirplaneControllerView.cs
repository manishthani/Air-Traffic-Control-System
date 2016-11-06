using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class AirplaneControllerView : MonoBehaviour {


	// UI Elements related to Add airplane
	public GameObject inputModelName;

	public GameObject textInputXWaypoints;
	public GameObject textInputYWaypoints;
	public GameObject textInputZWaypoints;

	public GameObject tableWaypoints;
	public GameObject waypointRowView; 

	// UI Scripts 
	private PopulateTables populateCoordinates; 

	void Start() {
		populateCoordinates = new PopulateTables();
	}

	public void addAirplaneEvent() {
		// Read data from inputs
		string modelName = inputModelName.GetComponent<Text>().text;

		string waypointXCoord = textInputXWaypoints.GetComponent<Text> ().text;
		string waypointYCoord = textInputYWaypoints.GetComponent<Text> ().text;
		string waypointZCoord = textInputZWaypoints.GetComponent<Text> ().text;
		ArrayList rowData = new ArrayList ();
		rowData.Add (waypointXCoord);
		rowData.Add (waypointYCoord);
		rowData.Add (waypointZCoord);

		// Populate List
		populateCoordinates.addRowToTable (tableWaypoints, waypointRowView, rowData);
		//

	}
}
