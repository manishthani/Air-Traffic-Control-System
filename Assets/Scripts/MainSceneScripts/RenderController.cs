using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class RenderController : MonoBehaviour {
	public static RenderController renderCtrl = null;

	public ArrayList allATC;

	void Start () {
		RenderController.renderCtrl = new RenderController ();
		VisualizationDataController.vdCtrl.setStartTime();

		instantiateAllAirplanes ();
		attachScripts ();
	}

	// Use this for initialization

	public void instantiateAllAirplanes () {

		// Obtaining airplanes from data controller
		ArrayList airplanes = DataController.dataCtrl.airplanes;
		allATC = new ArrayList();

		GameObject atcPrefab = Resources.Load ("ATC-System") as GameObject;
		GameObject waypointPrefab = Resources.Load ("Waypoint") as GameObject;

		foreach (AirplaneData airplaneData in airplanes) {
			
			// Cast to Vector 2 the waypoints
			ArrayList waypointsData = Utilities.parseToVector3(airplaneData.waypoints);

			// Instantiate airplane (waypoints[0] is the initial airplane position) 
			Vector3 airplanePos = (Vector3) waypointsData[0];
			GameObject atc = Instantiate (atcPrefab, new Vector3(airplanePos.x, airplanePos.z, airplanePos.y), atcPrefab.transform.rotation) as GameObject;

			Transform airplane = atc.transform.FindChild ("MyAirplane");

			// Set id and model name
			Text airplaneModelNameText = airplane.FindChild("Canvas").FindChild("textAirplaneModel").GetComponent<Text>();
			airplaneModelNameText.text = airplaneData.name;

			//Set waypoints position
			Transform parentWaypoint = atc.transform.FindChild("Waypoints");

			for (int i = 1; i < waypointsData.Count; ++i) {
				Vector3 waypointsPos = (Vector3) waypointsData[i];
				GameObject waypoint =  Instantiate (waypointPrefab,  new Vector3(waypointsPos.x, waypointsPos.z, waypointsPos.y), parentWaypoint.transform.rotation) as GameObject;
				waypoint.transform.SetParent (parentWaypoint.transform);
			}
				
			// Save Instance to collection of airplanes
			allATC.Add (atc);
		}
	}

	public void attachScripts () {
		foreach (GameObject atc in allATC) {
			GameObject myAirplane = atc.transform.FindChild ("MyAirplane").gameObject;
			// Airplane Scripts
			myAirplane.AddComponent<AircraftMovement> ();

			// Future Position scripts
			GameObject futurePositionParent = atc.transform.FindChild("FuturePositions").gameObject;

			futurePositionParent.AddComponent<LookAtFirstWaypoint> ();
			for (int i = 0; i < futurePositionParent.transform.childCount; ++i) {
				GameObject futurePosition = futurePositionParent.transform.GetChild (i).gameObject;
				futurePosition.AddComponent<FuturePosition> ();
			}

			// Radar scripts (AircraftDetector)
			Transform radar = myAirplane.transform.FindChild("Radar");
			for (int i = 0; i < radar.childCount; ++i) {
				radar.GetChild (i).gameObject.AddComponent<AircraftDetector> ();
			}
		}
	}

}
