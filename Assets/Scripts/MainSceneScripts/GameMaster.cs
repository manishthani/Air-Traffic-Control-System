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

	// Warning Panel Info
	public void hideWarningPanel() {
		UIController.UICtrl.hideWarningPanel ();
	}

	public void addInfoToWarningPanel (string airplaneModelName1, string airplaneModelName2, float timeForCollision) {
		UIController.UICtrl.eraseInfoInWarningPanel ();
		string warningInfo = "Collision of " + airplaneModelName1 + " and " + airplaneModelName2 + " in " + timeForCollision + " seconds!";
		UIController.UICtrl.addWarningPanelInfo(warningInfo);
	}

	public void loadResultScene () {
		LoadScenes.loadResultScene ();
	}

	public int totalAirplanes() {
		return airplanesMovement.Count;
	}

	private int getNumberAirplanesArrived() {
		int numberAirplanesArrived = 0;
		foreach(AircraftMovement airplaneMovement in airplanesMovement) {
			if (airplaneMovement != null) {
				if (airplaneMovement.hasArrivedInDestination ()) {
					++numberAirplanesArrived;
				}
			}
		}
		return numberAirplanesArrived;

	}

	// Update is called once per frame
	void Update () {
		airplanesMovement = new ArrayList ();
		GameObject[] airplaneObjects = GameObject.FindGameObjectsWithTag(Constants.AIRPLANETAG);
		for (int i = 0; i < airplaneObjects.Length; ++i) {
			airplanesMovement.Add (airplaneObjects[i].GetComponent<AircraftMovement>());
		}

		//if (airplanesMovement.Count != 0) {


			int numberAirplanesArrived = getNumberAirplanesArrived ();
			bool allAirplanesArrived = (numberAirplanesArrived == airplanesMovement.Count);
			VisualizationDataController.vdCtrl.totalAirplanesArrived = numberAirplanesArrived;
			VisualizationDataController.vdCtrl.totalAirplanesEnRoute = airplanesMovement.Count - numberAirplanesArrived;
			if (allAirplanesArrived) {
				loadResultScene ();
			}


			// Check for collisions
			destroyCloseAirplanes ();
		//}
	}

	public void destroyCloseAirplanes() {
		if (airplanesMovement != null) {
			for (int i = 0; i < airplanesMovement.Count; ++i) {
				AircraftMovement am1 = (AircraftMovement)airplanesMovement [i];
				for (int j = i + 1; j < airplanesMovement.Count; ++j) {
					AircraftMovement am2 = (AircraftMovement)airplanesMovement [j];
					if (Vector3.Distance (am1.getAirplanePosition (), am2.getAirplanePosition ()) < 1) {
						// Remove it from collections
						airplanesMovement.Remove(am1);
						airplanesMovement.Remove (am2);

						// Destroy ATCs
						Destroy (am1.transform.parent.gameObject);
						Destroy (am2.transform.parent.gameObject);

						// Stop Playing alarm
						stopAlert();
						// Increase variable in  Visualization Data
						VisualizationDataController.vdCtrl.totalCollisions += 2;
					}
				}
			}
		}
	}
}
