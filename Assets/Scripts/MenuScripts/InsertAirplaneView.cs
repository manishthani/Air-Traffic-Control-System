﻿using UnityEngine;
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

	// UI Scripts 
	private PopulateTables populateCoordinates; 

	// Data
	private int id = -1;
	private string coordinates;
	private string modelName;

	void Start() {
		populateCoordinates = new PopulateTables();
	}

	public void addAirplaneWaypointsEvent() {

		string waypointX = inputXWaypoints.GetComponent<InputField> ().text;
		string waypointY = inputYWaypoints.GetComponent<InputField> ().text;
		string waypointZ = inputZWaypoints.GetComponent<InputField> ().text;

		//Clear Inputs
		inputXWaypoints.GetComponent<InputField> ().text = string.Empty;
		inputYWaypoints.GetComponent<InputField> ().text = string.Empty;
		inputZWaypoints.GetComponent<InputField> ().text = string.Empty;

		// Add waypoint
		addWaypointsWithCoordinates (waypointX, waypointY, waypointZ);
	}

	public void insertAirplaneEvent() {
		// Read modelName from inputs
		modelName = inputModelName.GetComponent<InputField>().text;
		AirplaneViewController.airplaneViewCtrl.insertAirplanes (id, modelName, coordinates);
		clearAllFields ();
	}


	public void addWaypointsWithCoordinates (string waypointX, string waypointY, string waypointZ) {

		// Populate List
		ArrayList rowData = new ArrayList ();
		rowData.Add (waypointX);
		rowData.Add (waypointY);
		rowData.Add (waypointZ);

		populateCoordinates.addRowToTable (tableWaypoints, waypointRowView, rowData);

		coordinates += waypointX + "," + waypointY + "," + waypointZ + ";";
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
		foreach (Vector3 coordinates in waypointsArray) {
			addWaypointsWithCoordinates (coordinates.x.ToString (), coordinates.y.ToString (), coordinates.z.ToString ());
		}
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
		coordinates = string.Empty;
	}
}
