using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadResultsScene : MonoBehaviour {

	private ArrayList airplanesMovement;
	// Use this for initialization
	void Start () {
		airplanesMovement = new ArrayList ();

		GameObject[] airplaneObjects = GameObject.FindGameObjectsWithTag("Airplane");
		foreach (GameObject airplaneObject in airplaneObjects) {
			airplanesMovement.Add (airplaneObject.GetComponent<AircraftMovement>());
		}
	}
	
	// Update is called once per frame
	void Update () {
		bool allAirplanesArrived = true;
		foreach(AircraftMovement airplaneMovement in airplanesMovement) {
			if (!airplaneMovement.hasArrivedInDestination ()) {
				allAirplanesArrived = false;
			}
		}

		if (allAirplanesArrived) {
			SceneManager.LoadScene ("Results");
		}
	}
}
