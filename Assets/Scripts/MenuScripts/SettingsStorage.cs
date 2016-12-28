using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SettingsStorage : FileStorage {

	public SettingsStorage(string path) : base (path){
		
	}

	public SettingsModel readSettings() {
		if (File.Exists (Application.persistentDataPath + PATH)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + PATH, FileMode.Open);
			SettingsModel data = (SettingsModel)bf.Deserialize (file);
			file.Close ();
			return data;
		}
		return null;
	}

	public void updateSettings (SettingsModel data) {
		FileStream file = File.Open (Application.persistentDataPath + PATH, FileMode.Create);
		// We save all again
		BinaryFormatter bf = new BinaryFormatter ();
		bf.Serialize (file, data);
		file.Close ();
	}
}
