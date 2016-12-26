using UnityEngine;
using System.Collections;

public class LocalDataController  {
	private FileStorage fileStorage;

	public LocalDataController() {
		fileStorage = new FileStorage ();
	}

	public ArrayList Load () {		
		return fileStorage.Load ();
	}
		
	public void insertAirplane (string name , string waypoints) {
		AirplaneModel data = new AirplaneModel (-1, name , waypoints);
		fileStorage.Insert (data);
	}

	public void updateAirplane (int id, string name, string waypoints) {
		AirplaneModel data = new AirplaneModel (id, name, waypoints);
		fileStorage.Insert (data);
	}

	public void deleteAirplane(int id) {
		fileStorage.deleteAirplaneWithId (id);
	}

	public SettingsModel readSettings() {
		return fileStorage.readSettings();
	}

	public void updateSettings(int maxFutureDistance, int shortRadius, int longRadius, int speed) {
		SettingsModel data = new SettingsModel (maxFutureDistance, shortRadius, longRadius, speed);
		fileStorage.updateSettings (data);
	}
}

