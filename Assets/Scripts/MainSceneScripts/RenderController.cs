using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RenderController : MonoBehaviour {
	public static RenderController renderCtrl = null;
	public ArrayList allAirplanes;

	void Awake () {
		RenderController.renderCtrl = new RenderController ();
		LocalDataController.localDataCtrl = new LocalDataController ();
		instantiateAllAirplanes ();
		//insertDefaultAirplanes();
	}
		
	void insertDefaultAirplanes () {
		LocalDataController.localDataCtrl.Test ();
	}


	// Use this for initialization

	public void instantiateAllAirplanes () {
		// Obtaining airplanes from data layer
		ArrayList airplanes = LocalDataController.localDataCtrl.Load ();
		allAirplanes = new ArrayList();

		GameObject atcPrefab = Resources.Load ("ATC-System") as GameObject;
		foreach (AirplaneData airplaneData in airplanes) {

			// Cast to Vector 2 the waupoints
			ArrayList waypointsData = Utilities.parseToVector3(airplaneData.waypoints);

			// Instantiate airplane (waypoints[0] is the initial airplane position) 
			GameObject atc = Instantiate (atcPrefab, (Vector3)waypointsData[0], atcPrefab.transform.rotation) as GameObject;
			Transform airplane = atc.transform.FindChild ("MyAirplane");

			// Set id and model name
			// TODO: Find a way to set ID

			Text airplaneModelNameText = airplane.FindChild("Canvas").FindChild("textAirplaneModel").GetComponent<Text>();
			airplaneModelNameText.text = airplaneData.name;

			//Set waypoints position
			Transform[] waypoints = airplane.GetComponent<AircraftMovement>().targets;
			for (int i = 1; i < waypointsData.Count; ++i) {
				waypoints[i].position = (Vector3) waypointsData[i]; 
			}

			// Save Instance to collection of airplanes
			allAirplanes.Add (airplane);
		}

	}

}
