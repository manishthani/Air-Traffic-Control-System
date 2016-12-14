using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;


public class ShowAirplanesView : MonoBehaviour {

	// UI elements
	// Table elements
	public GameObject tableAirplanes;
	// TODO: Make assignment of airplaneLine and then set it to Is visible = false;
	public GameObject airplaneRowView; 

	// Delete rows elements
	public GameObject deletePanel;

	// UI Scripts 
	private PopulateTables populationAirplanes; 
	//Trajectories panel
	public GameObject trajectories;

	public void removeAirplanes () {
		for (int i = 0; i < tableAirplanes.transform.childCount; ++i) {
			// Only removes instances, not prefab
			if (tableAirplanes.transform.GetChild(i).name.Contains ("(Clone)")) {
				Destroy (tableAirplanes.transform.GetChild (i).gameObject);
			}
		}
	}

	public void populateAirplanes (ArrayList airplanesData) {
		populationAirplanes = new PopulateTables ();

		AirplaneTrajectoriesView atvScript = trajectories.GetComponent<AirplaneTrajectoriesView> ();
		atvScript.clean ();

		foreach (AirplaneModel data in airplanesData) {
			ArrayList rowData = new ArrayList ();
			rowData.Add (data.id.ToString());
			rowData.Add (data.name);
			rowData.Add (data.waypoints);

			populationAirplanes.addRowToTable (tableAirplanes, airplaneRowView, rowData);

			atvScript.drawAirplane (data.id, data.waypoints);
		}
	}

	public void checkboxDeleteEvent () {
		bool enabledDeletePanel = false;
		for (int i = 0; i < tableAirplanes.transform.childCount; ++i) {
			Transform row = tableAirplanes.transform.GetChild (i);
			if (row.Find ("Checkbox").GetComponent<Toggle> ().isOn) {
				enabledDeletePanel = true;
				break;
			}
		}
		deletePanel.SetActive (enabledDeletePanel);
	}

	public void cancelButtonInDeletePanelEvent() {
		for (int i = 0; i < tableAirplanes.transform.childCount; ++i) {
			Toggle checkbox = tableAirplanes.transform.GetChild (i).Find ("Checkbox").GetComponent<Toggle> ();
			if (checkbox.isOn) {
				checkbox.isOn = false;
			}
		}
		deletePanel.SetActive (false);
	}

	public void deleteButtonInDeletePanelEvent() {
		for (int i = 0; i < tableAirplanes.transform.childCount; ++i) {
			Transform row = tableAirplanes.transform.GetChild (i);
			Toggle checkbox = row.Find ("Checkbox").GetComponent<Toggle> ();

			if (checkbox.isOn) {
				int id = int.Parse(row.Find ("Id").GetComponent<Text> ().text);
				deleteAirplane (row, id);	
			}
		}
		deletePanel.SetActive (false);

		// TODO: Change it so it only asks to controller only the airplaneData so it can refresh it.
		refreshAirplanesTable ();
	}

	// Deletes view and also in the system
	public void deleteAirplane(Transform parent, int id) {
		AirplaneController.airplaneCtrl.deleteAirplaneWithId (id);
		Destroy (parent.gameObject);
	}


	public void refreshAirplanesTable () {
		// Communicates with the showAirplanesView and invokes a function to refresh the table by inserting the new airplane details
		ArrayList airplanes = AirplaneViewController.airplaneViewCtrl.getAirplanes();
		removeAirplanes ();
		populateAirplanes(airplanes);

	}
}
