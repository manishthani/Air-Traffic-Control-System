using UnityEngine;
using System.Collections;

public class LocalDataController  {
	private static string PATH_ATC = "/atc.dat"; 
	private static string PATH_SETTINGS = "/settings.dat";

	private AirplaneStorage airplaneStorage; 
	private SettingsStorage settingsStorage;

	public LocalDataController() {
		airplaneStorage = new AirplaneStorage (PATH_ATC);
		settingsStorage = new SettingsStorage (PATH_SETTINGS);
	}

	public ArrayList Load () {		
		return airplaneStorage.Load ();
	}
		
	public void insertAirplane (string name , string waypoints) {
		AirplaneModel data = new AirplaneModel (-1, name , waypoints);
		airplaneStorage.Insert (data);
	}

	public void updateAirplane (int id, string name, string waypoints) {
		AirplaneModel data = new AirplaneModel (id, name, waypoints);
		airplaneStorage.Insert (data);
	}

	public void deleteAirplane(int id) {
		airplaneStorage.deleteAirplaneWithId (id);
	}

	public SettingsModel readSettings() {
		return settingsStorage.readSettings();
	}

	public void updateSettings(int maxFutureDistance, int shortRadius, int longRadius, int speed) {
		SettingsModel data = new SettingsModel (maxFutureDistance, shortRadius, longRadius, speed);
		settingsStorage.updateSettings (data);
	}
}

