using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RenderController : MonoBehaviour {
	public static RenderController renderCtrl = null;

	public ArrayList allATC;

	public GameObject[] testAirplanes;
	public bool testEnabled = true;

	void Start () {
		RenderController.renderCtrl = new RenderController ();

		if (!testEnabled) {
			instantiateAllAirplanes ();
			attachScripts ();
		}
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
			GameObject atc = Instantiate (atcPrefab, (Vector3)waypointsData[0], atcPrefab.transform.rotation) as GameObject;
			Transform airplane = atc.transform.FindChild ("MyAirplane");

			// Set id and model name
			Text airplaneModelNameText = airplane.FindChild("Canvas").FindChild("textAirplaneModel").GetComponent<Text>();
			airplaneModelNameText.text = airplaneData.name;

			//Set waypoints position
			Transform parentWaypoint = atc.transform.FindChild("Waypoints");

			for (int i = 1; i < waypointsData.Count; ++i) {
				GameObject waypoint =  Instantiate (waypointPrefab, (Vector3) waypointsData [i], parentWaypoint.transform.rotation) as GameObject;
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
				futurePositionParent.transform.GetChild (i).gameObject.AddComponent<FuturePosition> ();
			}

			// Radar scripts (AircraftDetector)
			Transform radar = myAirplane.transform.FindChild("Radar");
			for (int i = 0; i < radar.childCount; ++i) {
				radar.GetChild (i).gameObject.AddComponent<AircraftDetector> ();
			}
		}
	}

}
