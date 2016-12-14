using UnityEngine;
using System;

[Serializable]
public class AirplaneModel {

	public int id;
	public string name;
	public string waypoints;
	//public ArrayList waypoints;

	public AirplaneModel (int id, string name, string waypoints) {
		this.id = id;
		this.name = name;
		this.waypoints = waypoints;
	} 
}