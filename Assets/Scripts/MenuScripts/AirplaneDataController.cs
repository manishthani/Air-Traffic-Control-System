using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AirplaneDataController {
	public static AirplaneDataController airplaneDataCtrl = null;

	// TODO: Find a way to reduce localDataCtrl.Load() calls

	private ArrayList airplanes;

	private static string PATH_ATC = "/atc.dat"; 
	private FileStorage airplaneStorage; 

	public ArrayList getAirplanes() {
		return airplanes;
	}
		
	// Use this for initialization
	public AirplaneDataController () {
		airplaneStorage = new AirplaneStorage (PATH_ATC);
		airplanes = Load ();
	}

	public ArrayList Load () {		
		return ((AirplaneStorage) airplaneStorage).Load ();
	}

	public void insertAirplane (string name , string waypoints) {
		AirplaneModel data = new AirplaneModel (-1, name , waypoints);
		((AirplaneStorage) airplaneStorage).Insert (data);
		airplanes = Load ();
	}

	public void updateAirplane (int id, string name, string waypoints) {
		AirplaneModel data = new AirplaneModel (id, name, waypoints);
		((AirplaneStorage) airplaneStorage).Insert (data);
		airplanes = Load ();
	}

	public void deleteAirplane(int id) {
		((AirplaneStorage) airplaneStorage).deleteAirplaneWithId (id);
		airplanes = Load ();
	}



}
