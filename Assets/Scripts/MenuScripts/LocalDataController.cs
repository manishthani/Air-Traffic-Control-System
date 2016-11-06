using UnityEngine;
using System.Collections;

public class LocalDataController {
	public static LocalDataController localDataCtrl; 
	private LocalData localData;


	public LocalDataController() {
		localData = new LocalData ();
	}

	public ArrayList Load () {		
		return localData.Load ();
	}
		
	public void Insert (int id, string name , string waypoints) {
		AirplaneData data = new AirplaneData (id, name , waypoints);
		localData.Insert (data);
	}

	public void Test () {
		
		/*ArrayList load = Load ();
		load = Load ();
		foreach ( AirplaneData d in load) {
			Debug.Log ("Airplane name: " +d.name + "id: " + d.id);
		}*/
		// int id, string name, Vector3 initPosition, ArrayList waypoints

		//INSERT
		ArrayList arrayWaypoints = new ArrayList();

		arrayWaypoints.Add ( new Vector3(40.89946f, 6.0f, 34.5229f) ); 
		arrayWaypoints.Add ( new Vector3(-6.619187f, 6.0f, 55.04213f) ); 
		arrayWaypoints.Add ( new Vector3(1.751162f, 6.0f, 98.54417f) ); 
		arrayWaypoints.Add ( new Vector3(28.53522f, 6.0f, 115.488f) ); 
		arrayWaypoints.Add ( new Vector3(39.87203f, 6.0f, 174.407f) ); 
		arrayWaypoints.Add ( new Vector3(250.0f, 0.0f, 250.0f) ); 

		string waypoints = Utilities.parseToString(arrayWaypoints);
		Insert (1, "Boeing 39231", waypoints);


		arrayWaypoints = new ArrayList();

		arrayWaypoints.Add ( new Vector3(20.89946f,6.0f,34.5229f) ); 
		arrayWaypoints.Add ( new Vector3(-6.619187f, 6.0f, 55.04213f) ); 
		arrayWaypoints.Add ( new Vector3(1.751162f, 6.0f, 98.54417f) ); 
		arrayWaypoints.Add ( new Vector3(28.53522f, 6.0f, 115.488f) ); 
		arrayWaypoints.Add ( new Vector3(39.87203f, 6.0f, 174.407f) ); 
		arrayWaypoints.Add ( new Vector3(-250.0f, 0.0f, 0.0f) ); 

		waypoints = Utilities.parseToString(arrayWaypoints);

		Insert (2, "Boeing 39231", waypoints);

		//READ
		/*ArrayList array = Load();
		foreach (AirplaneData data in array) {
			Debug.Log ("ID: " + data.id +  ", NAME:" + data.name );
			ArrayList positions = Utilities.parseToVector3 (data.waypoints);
			int i = 0;
			foreach (Vector3 position in positions ) {
				Debug.Log("Position " + i + ":" + "(" + position.x + "," + position.y + "," + position.z + ")");
				++i;
			}

		}*/

		/* // DELETE
			

		*/

		/* // UPDATE

		*/
	}
}

