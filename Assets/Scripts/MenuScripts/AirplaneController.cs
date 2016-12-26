using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AirplaneController {
	public static AirplaneController airplaneCtrl = null;

	// TODO: Find a way to reduce localDataCtrl.Load() calls

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
		localDataCtrl.insertAirplane (modelName, waypoints);
		airplanes = localDataCtrl.Load ();
	}

	public void updateAirplane(int id, string modelName, string waypoints) {
		localDataCtrl.updateAirplane (id, modelName, waypoints);
		airplanes = localDataCtrl.Load ();
	}

	public void deleteAirplaneWithId (int id) {
		localDataCtrl.deleteAirplane (id);
		airplanes = localDataCtrl.Load ();
	}
}
