using UnityEngine;
using System.Collections;

public class ShowAirplanesView : MonoBehaviour {

	public GameObject tableAirplanes;
	public GameObject airplaneRowView; 


	// TODO: Populate Table and refresh table functions needed

	// UI Scripts 
	private PopulateTables populateCoordinates; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void removeAirplanes () {
		for (int i = 0; i < tableAirplanes.transform.childCount; ++i) {
			// Only removes instances, not prefab
			if (tableAirplanes.transform.GetChild(i).name.Contains ("(Clone)")) {
				Destroy (tableAirplanes.transform.GetChild (i).gameObject);
			}
		}
	}

	public void populateAirplanes (ArrayList airplanesData) {
		populateCoordinates = new PopulateTables ();
		foreach (AirplaneData data in airplanesData) {
			ArrayList rowData = new ArrayList ();
			rowData.Add (data.id.ToString());
			rowData.Add (data.name);
			rowData.Add (data.waypoints);

			populateCoordinates.addRowToTable (tableAirplanes, airplaneRowView, rowData);
		}
	}
}
