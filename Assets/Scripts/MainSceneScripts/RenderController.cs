using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class RenderController : MonoBehaviour {
	public static RenderController renderCtrl = null;

	void Start () {
		RenderController.renderCtrl = new RenderController ();
		//if (DataController.dataCtrl != null) {
		ArrayList allATC = instantiateAllAirplanes ();
		attachScripts (allATC);
		//}
		VisualizationDataController.vdCtrl.setStartTime();

	}


	public ArrayList instantiateAllAirplanes () {

		// Obtaining airplanes from data controller

		ArrayList airplanes = DataController.dataCtrl.airplanes;
		ArrayList atcList = new ArrayList();

		GameObject atcPrefab = Resources.Load (Constants.ATCSYSTEM) as GameObject;
		GameObject waypointPrefab = Resources.Load (Constants.WAYPOINT) as GameObject;

		foreach (AirplaneModel airplaneData in airplanes) {
			
			// Cast to Vector 2 the waypoints
			ArrayList waypointsData = Utilities.parseToVector3(airplaneData.waypoints);

			// Instantiate airplane (waypoints[0] is the initial airplane position) 
			Vector3 airplanePos = (Vector3) waypointsData[0];

			GameObject atc = Instantiate (atcPrefab, Vector3.zero, atcPrefab.transform.rotation) as GameObject;
			atc.name = airplaneData.id.ToString ();

			Transform airplane = atc.transform.FindChild (Constants.MYAIRPLANE);
			airplane.position = new Vector3 (airplanePos.x, airplanePos.z / Constants.FEETTOMILE, airplanePos.y);

			// Set id and model name
			Text airplaneModelNameText = airplane.FindChild(Constants.CANVAS).FindChild(Constants.TEXTAIRPLANEMODEL).GetComponent<Text>();
			airplaneModelNameText.text = airplaneData.name;

			//Set waypoints position
			Transform parentWaypoint = atc.transform.FindChild(Constants.WAYPOINTS);

			for (int i = 1; i < waypointsData.Count; ++i) {
				Vector3 waypointsPos = (Vector3) waypointsData[i];
				GameObject waypoint =  Instantiate (waypointPrefab,  new Vector3(waypointsPos.x, waypointsPos.z / Constants.FEETTOMILE, waypointsPos.y), parentWaypoint.transform.rotation) as GameObject;
				waypoint.transform.SetParent (parentWaypoint.transform);
			}
				
			// Save Instance to collection of airplanes
			atcList.Add (atc);
		}
		return atcList;
	}

	public void attachScripts (ArrayList allATC) {
		foreach (GameObject atc in allATC) {
			GameObject myAirplane = atc.transform.FindChild (Constants.MYAIRPLANE).gameObject;
			// Airplane Scripts
			myAirplane.AddComponent<AircraftMovement> ();
			// Future Position scripts
			GameObject futurePositionParent = atc.transform.FindChild(Constants.FUTUREPOSITIONS).gameObject;
			futurePositionParent.transform.position = myAirplane.transform.position;
			futurePositionParent.AddComponent<LookAtFirstWaypoint> ();
			for (int i = 0; i < futurePositionParent.transform.childCount; ++i) {
				GameObject futurePosition = futurePositionParent.transform.GetChild (i).gameObject;
				futurePosition.AddComponent<FuturePosition> ();
			}

			// Radar scripts (AircraftDetector)
			Transform radar = myAirplane.transform.FindChild(Constants.RADAR);
			for (int i = 0; i < radar.childCount; ++i) {
				radar.GetChild (i).gameObject.AddComponent<AircraftDetector> ();
			}
		}
	}

}
