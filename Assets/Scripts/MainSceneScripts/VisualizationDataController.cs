using UnityEngine;
using System;
using System.Collections;

public class  VisualizationDataController : MonoBehaviour {
	// TODO: total airplanes arrived is not necessary equal to the total number of airplanes in the system
	public static VisualizationDataController vdCtrl = null;

	private DateTime startTime;
	private TimeSpan totalTime; 

	public int totalConflicts = 0;
	public int totalCollisions = 0;
	public int totalAirplanesArrived = 0;
	public int totalAirplanesEnRoute = 0;


	public void setStartTime() {
		startTime = DateTime.Now;
	}

	public TimeSpan getTotalTime() {
		return totalTime;
	}

	public void setTotalTime () {
		totalTime = DateTime.Now.Subtract(startTime);
	}

	void Awake() {
		DontDestroyOnLoad(this);
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}

	}

	// Use this for initialization
	void Start () {
		if (vdCtrl == null) {
			vdCtrl = new VisualizationDataController ();
		}


	}

	// TODO: Why is this in Update Function?
	void Update() {
		if (GameMaster.gm != null) {
			totalAirplanesArrived = GameMaster.gm.totalAirplanes();
		}
	}
}
