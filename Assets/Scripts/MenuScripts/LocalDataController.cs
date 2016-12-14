using UnityEngine;
using System.Collections;

public class LocalDataController : MonoBehaviour{
	private FileStorage fileStorage;


	public LocalDataController() {
		fileStorage = new FileStorage ();
	}

	public ArrayList Load () {		
		return fileStorage.Load ();
	}
		
	public void insert (string name , string waypoints) {
		AirplaneModel data = new AirplaneModel (-1, name , waypoints);
		fileStorage.Insert (data);
	}

	public void update (int id, string name, string waypoints) {
		AirplaneModel data = new AirplaneModel (id, name, waypoints);
		fileStorage.Insert (data);
	}

	public void delete(int id) {
		fileStorage.deleteAirplaneWithId (id);
	}
}

