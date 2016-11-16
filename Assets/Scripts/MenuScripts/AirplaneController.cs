using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AirplaneController {
	public static AirplaneController airplaneCtrl = null;

	// TODO: Find a way to reduce localDataCtrl.Load() calls
	// TODO: WHen deleting objects, add to the refresh function to destroy all airplane lines and add them again without the deleted airplane
	// Airplanes
	private ArrayList airplanes;
	private LocalDataController localDataCtrl;


	public ArrayList getAirplanes() {
		return airplanes;
	}

	// Use this for initialization
	public AirplaneController () {
		localDataCtrl = new LocalDataController ();
		airplanes = localDataCtrl.Load ();
	}

	public void insertAirplane(string modelName, string waypoints) {
		localDataCtrl.insert (modelName, waypoints);
		airplanes = localDataCtrl.Load ();
	}

	public void updateAirplane(int id, string modelName, string waypoints) {
		localDataCtrl.update (id, modelName, waypoints);
		airplanes = localDataCtrl.Load ();
	}

	public void deleteAirplaneWithId (int id) {
		localDataCtrl.delete (id);
		airplanes = localDataCtrl.Load ();
	}
}
