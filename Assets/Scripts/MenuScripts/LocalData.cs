﻿using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LocalData {

	public static String PATH = "/atc.dat";

	public void Save(AirplaneData data) {
		FileStream file;
		if (!File.Exists (Application.persistentDataPath + PATH)) {
			file = File.Open (Application.persistentDataPath + PATH, FileMode.OpenOrCreate);
		} else {
			file = File.Open (Application.persistentDataPath + PATH, FileMode.Append);
		}

		BinaryFormatter bf = new BinaryFormatter ();
		bf.Serialize (file, data);
		file.Close ();

	}

	public ArrayList Load() {
		ArrayList playersData = new ArrayList ();

		if (File.Exists (Application.persistentDataPath + PATH)) {
			BinaryFormatter bf = new BinaryFormatter ();

			FileStream file = File.Open (Application.persistentDataPath + PATH, FileMode.Open);
			while(file.Position != file.Length){
				AirplaneData data = (AirplaneData)bf.Deserialize (file);

				playersData.Add (data);
			}
			file.Close();
		}
		return playersData;
	}


	public int Insert (AirplaneData airplaneData) {
		ArrayList allData = Load();
		bool airplaneExist = (airplaneData.id != -1);
		if (airplaneExist) {
			foreach (AirplaneData p in allData) {
				if (p.id == airplaneData.id ) {
					airplaneExist = true; 

					p.id = airplaneData.id;
					p.name = airplaneData.name;
					p.waypoints = airplaneData.waypoints;

					break;
				}
			}
			SaveAll (allData, FileMode.OpenOrCreate);
		} else {
			int maxId = 0;
			foreach (AirplaneData p in allData) {
				if (p.id > maxId) {
					maxId = p.id;
				}
			}
			airplaneData.id = maxId + 1;
			Save (airplaneData);
		}
		return airplaneData.id;
	}

	public void deleteAirplaneWithId (int id) {
		ArrayList allData = Load ();
		foreach (AirplaneData p in allData) {
			if (p.id == id ) {
				allData.Remove (p);
				break;
			}
		}
		SaveAll (allData, FileMode.Truncate);
	}

	public void SaveAll(ArrayList allData, FileMode mode) {
		
		FileStream file = File.Open (Application.persistentDataPath + PATH, mode);
		// Guardamos todo de nuevo
		BinaryFormatter bf = new BinaryFormatter ();
		foreach (AirplaneData data in allData) {
			bf.Serialize (file, data);
		}
		file.Close ();
	}
}

[Serializable]
public class AirplaneData {

	public int id;
	public string name;
	public string waypoints;
	//public ArrayList waypoints;

	public AirplaneData (int id, string name, string waypoints) {
		this.id = id;
		this.name = name;
		this.waypoints = waypoints;
	} 
}