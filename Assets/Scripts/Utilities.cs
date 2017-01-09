using UnityEngine;
using System.Collections;

public class Utilities {

	public static string parseToString (ArrayList vector) {
		string vectorString = "";
		for (int i = 0; i < vector.Count; ++i) {
			Vector3 position = (Vector3)vector[i];
			vectorString += position.x + "," + position.y + "," + position.z;
			if (i != vector.Count - 1) {
				vectorString += ";";
			}
		}
		return vectorString;
	}

	public static ArrayList parseToVector3 (string vector) {
		ArrayList array = new ArrayList ();
		string[] positions = vector.Split(';');

		for (int i = 0; i < positions.Length;  ++i) {
			if (positions[i] != string.Empty) {
				string[] position = positions [i].Split (',');
				Vector3 positionVector = new Vector3 (float.Parse (position [0]), float.Parse (position [1]), float.Parse (position [2]));
				array.Add (positionVector);
			}
		}
		return array;
	}
		
}
