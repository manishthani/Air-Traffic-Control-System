using UnityEngine;
using System.Collections;

//QualitySettings.vSyncCount = 0;
//Application.targetFrameRate = frameRate;

public class AircraftMovement : MonoBehaviour {


	public float currentSpeed = 600.0f;
	public float realSpeed = 600.0f;
	public float knots = 600.0f;

	private GameObject camera3D;

	private ArrayList targets;
	private bool destinationArrived = false;

	// Begins at 1 since 0 is the initial position of aircraft
	private int index = 1;
	private const float secondsPerHour = 3600.0f;


	public bool hasArrivedInDestination() {
		return destinationArrived;
	}

	public Transform getCurrentTarget () {
		return (Transform) targets [index];
	}
	public Transform getNextFutureTarget() {
		return (Transform) targets [index + 1];
	}

	public bool existNextFutureTarget() {
		return index + 1 < targets.Count;
	}

	public bool existMoreTargets () {
		return index < targets.Count;
	}
		

	void Awake() {
		targets = new ArrayList();
		// Add Initial position
		targets.Add (transform.position);
		Transform waypoints = transform.parent.FindChild (Constants.WAYPOINTS);
		for (int i = 0; i < waypoints.childCount; ++i) {
			targets.Add (waypoints.GetChild (i));
		}
		// Cambiar esto
		camera3D = transform.Find(Constants.RADAR).Find(Constants.LONGRANGEDETECTOR).gameObject;
		UIController.UICtrl.addAirplaneInMiniatureImage (transform.parent.name, transform.position);

	}


		
	void Update () {
		if (!destinationArrived) {
			float acceleration = UIController.UICtrl.getSpeedSliderValue ();
			currentSpeed = (knots / secondsPerHour * Time.deltaTime) * acceleration;
			realSpeed = knots / secondsPerHour * acceleration;
			if (transform.position == ((Transform)targets [index]).position && existNextFutureTarget ()) {
				index++;
			}

			transform.LookAt (getCurrentTarget ().position);

			if (existMoreTargets () && camera3D.activeSelf) {
				camera3D.GetComponent<CameraMovement> ().manageCamera3DControlsOfNextWaypoint (gameObject, getCurrentTarget ());
			}
				
			if (existMoreTargets ()) {

				transform.position = Vector3.MoveTowards (transform.position, ((Transform)targets [index]).position, currentSpeed);
				if (((Transform)targets [index]).position == transform.position && !existNextFutureTarget ()) {
					destinationArrived = true;
					Debug.Log ("Airplane arrived in destination");
				}
			} 
			Vector3 currentTarget = getCurrentTarget ().position;
			Vector2 currentTarget2D = new Vector2 (currentTarget.x, currentTarget.z);
			UIController.UICtrl.updateAirplaneInMiniatureImage (transform.parent.name, transform.position, transform.GetComponent<MeshRenderer> ().material.color, currentTarget2D);
		}
	}

	void OnCollisionEnter(Collision other) {
		GameObject atc = gameObject.transform.parent.gameObject;
		Destroy (atc);
		// Increment Number Collisions results Panel
		VisualizationDataController.vdCtrl.totalCollisions++;
	}

	public Vector3 getAirplanePosition () {
		return transform.position;
	}
}
