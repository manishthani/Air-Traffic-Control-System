using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIAirplanePanel : MonoBehaviour {
	public GameObject GUIUserLine;
	private float offset = 30.0f;
	private int rankIndex = 1;
	private int i = 0;
	 void Start() {
		LocalDataController.localDataCtrl = new LocalDataController ();
		ArrayList airplanes = LocalDataController.localDataCtrl.Load();
		foreach (AirplaneData data in airplanes) {
			populateAirplanePanel (data.id.ToString(), data.name, data.waypoints);
		}
		//Test Data
		/*ArrayList arrayWaypoints = new ArrayList();

		arrayWaypoints.Add ( new Vector3(40.89946f, 6.0f, 34.5229f) ); 
		arrayWaypoints.Add ( new Vector3(-6.619187f, 6.0f, 55.04213f) ); 
		arrayWaypoints.Add ( new Vector3(1.751162f, 6.0f, 98.54417f) ); 
		arrayWaypoints.Add ( new Vector3(28.53522f, 6.0f, 115.488f) ); 
		arrayWaypoints.Add ( new Vector3(39.87203f, 6.0f, 174.407f) ); 
		arrayWaypoints.Add ( new Vector3(250.0f, 0.0f, 250.0f) ); 

		string waypoints = Utilities.parseToString(arrayWaypoints);
		populateAirplanePanel ("1", "Boeing 707", waypoints);

		arrayWaypoints = new ArrayList();

		arrayWaypoints.Add ( new Vector3(20.89946f,6.0f,34.5229f) ); 
		arrayWaypoints.Add ( new Vector3(-6.619187f, 6.0f, 55.04213f) ); 
		arrayWaypoints.Add ( new Vector3(1.751162f, 6.0f, 98.54417f) ); 
		arrayWaypoints.Add ( new Vector3(28.53522f, 6.0f, 115.488f) ); 
		arrayWaypoints.Add ( new Vector3(39.87203f, 6.0f, 174.407f) ); 
		arrayWaypoints.Add ( new Vector3(-250.0f, 0.0f, 0.0f) ); 

		waypoints = Utilities.parseToString(arrayWaypoints);

		populateAirplanePanel ("4", "Airbus 303", waypoints);
		arrayWaypoints = new ArrayList();

		arrayWaypoints.Add ( new Vector3(20.89946f,6.0f,34.5229f) ); 
		arrayWaypoints.Add ( new Vector3(-6.619187f, 6.0f, 55.04213f) ); 
		arrayWaypoints.Add ( new Vector3(1.751162f, 6.0f, 98.54417f) ); 
		arrayWaypoints.Add ( new Vector3(28.53522f, 6.0f, 115.488f) ); 
		arrayWaypoints.Add ( new Vector3(39.87203f, 6.0f, 174.407f) ); 
		arrayWaypoints.Add ( new Vector3(-250.0f, 0.0f, 0.0f) ); 

		waypoints = Utilities.parseToString(arrayWaypoints);

		populateAirplanePanel ("4", "Airbus 303", waypoints);
		arrayWaypoints = new ArrayList();

		arrayWaypoints.Add ( new Vector3(20.89946f,6.0f,34.5229f) ); 
		arrayWaypoints.Add ( new Vector3(-6.619187f, 6.0f, 55.04213f) ); 
		arrayWaypoints.Add ( new Vector3(1.751162f, 6.0f, 98.54417f) ); 
		arrayWaypoints.Add ( new Vector3(28.53522f, 6.0f, 115.488f) ); 
		arrayWaypoints.Add ( new Vector3(39.87203f, 6.0f, 174.407f) ); 
		arrayWaypoints.Add ( new Vector3(-250.0f, 0.0f, 0.0f) ); 

		waypoints = Utilities.parseToString(arrayWaypoints);

		populateAirplanePanel ("4", "Airbus 303", waypoints);
		arrayWaypoints = new ArrayList();

		arrayWaypoints.Add ( new Vector3(20.89946f,6.0f,34.5229f) ); 
		arrayWaypoints.Add ( new Vector3(-6.619187f, 6.0f, 55.04213f) ); 
		arrayWaypoints.Add ( new Vector3(1.751162f, 6.0f, 98.54417f) ); 
		arrayWaypoints.Add ( new Vector3(28.53522f, 6.0f, 115.488f) ); 
		arrayWaypoints.Add ( new Vector3(39.87203f, 6.0f, 174.407f) ); 
		arrayWaypoints.Add ( new Vector3(-250.0f, 0.0f, 0.0f) ); 

		waypoints = Utilities.parseToString(arrayWaypoints);

		populateAirplanePanel ("4", "Airbus 303", waypoints);
		arrayWaypoints = new ArrayList();

		arrayWaypoints.Add ( new Vector3(20.89946f,6.0f,34.5229f) ); 
		arrayWaypoints.Add ( new Vector3(-6.619187f, 6.0f, 55.04213f) ); 
		arrayWaypoints.Add ( new Vector3(1.751162f, 6.0f, 98.54417f) ); 
		arrayWaypoints.Add ( new Vector3(28.53522f, 6.0f, 115.488f) ); 
		arrayWaypoints.Add ( new Vector3(39.87203f, 6.0f, 174.407f) ); 
		arrayWaypoints.Add ( new Vector3(-250.0f, 0.0f, 0.0f) ); 

		waypoints = Utilities.parseToString(arrayWaypoints);

		populateAirplanePanel ("4", "Airbus 303", waypoints);*/

	}

	private void populateAirplanePanel (string id, string modelName, string waypoints) {
		GameObject instance = Instantiate (GUIUserLine) as GameObject;
		instance.transform.SetParent (transform, false);

		instance.transform.Translate (new Vector3 (0, -offset, 0.0f));

		Text[] texts = instance.GetComponentsInChildren<Text> ();

		// Populate the new instance with given username and score
		texts[0].text = id;
		texts[1].text = modelName;
		texts[2].text = waypoints;

		offset += 30.0f;
		++rankIndex;
		++i;

	}
}
