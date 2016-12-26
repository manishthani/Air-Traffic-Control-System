using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class FileStorage {
	public string PATH_ATC = "/atc.dat"; 
	public string PATH_SETTINGS = "/settings.dat";

	public void Save(AirplaneModel data) {
		FileStream file;
		if (!File.Exists (Application.persistentDataPath + PATH_ATC)) {
			file = File.Open (Application.persistentDataPath + PATH_ATC, FileMode.OpenOrCreate);
		} else {
			file = File.Open (Application.persistentDataPath + PATH_ATC, FileMode.Append);
		}

		BinaryFormatter bf = new BinaryFormatter ();
		bf.Serialize (file, data);
		file.Close ();

	}

	public ArrayList Load() {
		ArrayList playersData = new ArrayList ();
		Debug.Log (Application.persistentDataPath);
		if (File.Exists (Application.persistentDataPath + PATH_ATC)) {
			BinaryFormatter bf = new BinaryFormatter ();

			FileStream file = File.Open (Application.persistentDataPath + PATH_ATC, FileMode.Open);
			while(file.Position != file.Length){
				AirplaneModel data = (AirplaneModel)bf.Deserialize (file);

				playersData.Add (data);
			}
			file.Close();
		}
		return playersData;
	}


	public int Insert (AirplaneModel airplaneData) {
		ArrayList allData = Load();
		bool airplaneExist = (airplaneData.id != -1);
		if (airplaneExist) {
			foreach (AirplaneModel p in allData) {
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
			foreach (AirplaneModel p in allData) {
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
		foreach (AirplaneModel p in allData) {
			if (p.id == id ) {
				allData.Remove (p);
				break;
			}
		}
		SaveAll (allData, FileMode.Truncate);
	}

	public void SaveAll(ArrayList allData, FileMode mode) {
		
		FileStream file = File.Open (Application.persistentDataPath + PATH_ATC, mode);
		// We save all again
		BinaryFormatter bf = new BinaryFormatter ();
		foreach (AirplaneModel data in allData) {
			bf.Serialize (file, data);
		}
		file.Close ();
	}


	public SettingsModel readSettings() {
		if (File.Exists (Application.persistentDataPath + PATH_SETTINGS)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + PATH_SETTINGS, FileMode.Open);
			SettingsModel data = (SettingsModel)bf.Deserialize (file);
			file.Close ();
			return data;
		}
		return null;
	}

	public void updateSettings (SettingsModel data) {
		FileStream file = File.Open (Application.persistentDataPath + PATH_SETTINGS, FileMode.Create);
		// We save all again
		BinaryFormatter bf = new BinaryFormatter ();
		bf.Serialize (file, data);
		file.Close ();
	}
}
	