using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameMaster : MonoBehaviour {
	public static GameMaster gm = null;

	private ArrayList airplanesMovement;

	void Start () {
		if (gm == null) {
			gm = new GameMaster ();
		}
		airplanesMovement = new ArrayList ();
		GameObject[] airplaneObjects = GameObject.FindGameObjectsWithTag("Airplane");
		foreach (GameObject airplaneObject in airplaneObjects) {
			airplanesMovement.Add (airplaneObject.GetComponent<AircraftMovement>());
		}
	}

	// Sound Alerts
	public void playAlert () {
		AudioController.audioCtrl.PlayAudioSource ();
	}

	public void stopAlert() {
		AudioController.audioCtrl.StopAudioSource ();
		UIController.UICtrl.hideWarningPanel ();
	}


	// Conflict Panel Info
	public void addInfoToConflictPanel(string conflictInfo) {
		UIController.UICtrl.addCollisionInfo (conflictInfo);
	}


	// Warning Panel Info
	public void showWarningPanel() {
		UIController.UICtrl.showWarningPanel ();
	}

	public void addInfoToWarningPanel (string airplaneModelName1, string airplaneModelName2, int futurePosition) {
		
	}

	public void loadResultScene () {
		LoadScenes.loadResultScene ();
	}

	public int totalAirplanes() {
		return airplanesMovement.Count;
	}

	// Update is called once per frame
	void Update () {
		bool allAirplanesArrived = true;

		foreach(AircraftMovement airplaneMovement in airplanesMovement) {
			if (airplaneMovement != null) {
				if (!airplaneMovement.hasArrivedInDestination ()) {
					allAirplanesArrived = false;
				}
			}
			else allAirplanesArrived = false;
		}

		if (allAirplanesArrived) {
			LoadScenes.loadResultScene ();
		}
	}
}
