﻿using UnityEngine;
using System.Collections;

public class AircraftMovement : MonoBehaviour {

	//public int frameRate = 2;
	public float knots = 600.0f;

	private ArrayList targets;

	private bool destinationArrived = false;

	// Begins at 1 since 0 is the initial position of aircraft
	private int index = 1;
	private const float secondsPerHour = 3600.0f;

	public bool hasArrivedInDestination() {
		return destinationArrived;
	}

	public void incrementIndex() {
		index = index + 1;
	}

	public Transform getCurrentTarget () {
		return (Transform) targets [index];
	}
	public Transform getNextFutureTarget() {
		return (Transform) targets [index + 1];
	}

	public bool existNextFutureTarget() {
		return index + 1 < targets.Count;
	}

	public bool existMoreTargets () {
		return index < targets.Count;
	}
		

	void Awake() {
		//QualitySettings.vSyncCount = 0;
		//Application.targetFrameRate = frameRate;
		targets = new ArrayList();
		// Add Initial position
		targets.Add (transform.position);
		Transform waypoints = transform.parent.FindChild ("Waypoints").transform;

		for (int i = 0; i < waypoints.childCount; ++i) {
			targets.Add (waypoints.GetChild (i));
		}
		Debug.Log ("START");
	}

	// Update is called once per frame
	void Update () {

		float step = knots / secondsPerHour * Time.deltaTime;
		if (transform.position == ((Transform) targets [index]).position && existNextFutureTarget()) {
			index++;
		}

		if (existMoreTargets ()) {
			transform.position = Vector3.MoveTowards (transform.position, ((Transform)targets [index]).position, step);
			if (((Transform)targets [index]).position == transform.position && !existNextFutureTarget ()) {
				Debug.Log("Airplane Trajectory Completed");
				destinationArrived = true;
			}
		} 
	}
}
