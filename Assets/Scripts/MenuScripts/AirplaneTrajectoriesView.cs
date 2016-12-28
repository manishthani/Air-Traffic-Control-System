using UnityEngine;
using UnityEngine.UI.Extensions;
using System.Collections;

public class AirplaneTrajectoriesView : MonoBehaviour {
	private float height; 
	private float width;

	// GameObjects
	private GameObject airplaneTrajectory;
	private GameObject waypointIcon;
	private RectTransform airplaneTrajectoryRect;

	// Use this for initialization
	void Awake () {
		height = transform.GetComponent<RectTransform> ().rect.height;
		width = transform.GetComponent<RectTransform> ().rect.width;

		refresh ();
	}

	// Update is called once per frame

	// TODO: (0,0) is the left lower corner and (500,500) is the right higher corner
	public void drawAirplane(int id, string waypoints) {
		if (airplaneTrajectory == null) {
			airplaneTrajectory = Resources.Load (Constants.AIRPLANETRAJECTORY) as GameObject;
			airplaneTrajectoryRect = airplaneTrajectory.GetComponent<RectTransform> ();
		}
		if (waypointIcon == null) {
			waypointIcon = Resources.Load (Constants.WAYPOINTICON) as GameObject;
		}
			
		if (waypoints != string.Empty) {
			ArrayList waypointsInstances = new ArrayList ();
			// Normalize waypoints to range 0 - 500.0f, then divide into 2 
			ArrayList waypointsArray = Utilities.parseToVector3 (waypoints);
			for (int i = 0; i < waypointsArray.Count; i++) {
				waypointsArray [i] = new Vector3 (((Vector3)waypointsArray [i]).x * (width / Constants.TERRAINSIZE) - (width/2.0f) ,((Vector3)waypointsArray [i]).y * (height / Constants.TERRAINSIZE) - (height/2.0f),  1.0f );
			}

			//Draw airplane icon
			GameObject instanceTrajectory = Instantiate (airplaneTrajectory, Vector3.zero, transform.rotation) as GameObject;
			instanceTrajectory.name = id.ToString ();
			instanceTrajectory.transform.SetParent (transform);

			// TODO: Make this look cleaner!
			RectTransform rect = instanceTrajectory.GetComponent<RectTransform> ();
			rect.offsetMax = airplaneTrajectoryRect.offsetMax;
			rect.offsetMin = airplaneTrajectoryRect.offsetMin;
			rect.pivot = airplaneTrajectoryRect.pivot;
			rect.position = airplaneTrajectoryRect.position;
			rect.localScale = airplaneTrajectoryRect.localScale;
			rect.anchoredPosition = airplaneTrajectoryRect.anchoredPosition;
			rect.localPosition = airplaneTrajectoryRect.localPosition;
			rect = airplaneTrajectoryRect;



			instanceTrajectory.GetComponent<RectTransform> ().localPosition = Vector3.zero;

			Transform instanceAirplane = instanceTrajectory.transform.Find (Constants.AIRPLANEICON);
			instanceAirplane.GetComponent<RectTransform> ().localPosition = (Vector3)waypointsArray [0];

			waypointsInstances.Add (new Vector2 (instanceAirplane.transform.localPosition.x + (width / 2), instanceAirplane.transform.localPosition.y + (height / 2.0f)));

			// Draw waypoints
			for (int i = 1; i < waypointsArray.Count; ++i) {
				GameObject instanceWaypoint = Instantiate (waypointIcon, (Vector3)waypointsArray [i], transform.rotation) as GameObject;

				instanceWaypoint.transform.SetParent (instanceTrajectory.transform);

				instanceWaypoint.GetComponent<RectTransform> ().localPosition = (Vector3)waypointsArray [i];

				waypointsInstances.Add (new Vector2 (instanceWaypoint.transform.localPosition.x + (width / 2), instanceWaypoint.transform.localPosition.y + (height / 2.0f)));
			}

			Vector2[] waypoints2DArray = (Vector2[])waypointsInstances.ToArray (typeof(Vector2));

			UILineRenderer renderer = instanceTrajectory.GetComponent<UILineRenderer> ();

			renderer.Points = waypoints2DArray;
		}
	}

	public void refresh () {
		clean ();
		// Draw airplanes again
		ArrayList airplanes = AirplaneController.airplaneCtrl.getAirplanes ();
		foreach (AirplaneModel airplane in airplanes) {
			drawAirplane (airplane.id, airplane.waypoints);
		}
	}

	public void clean() {
		foreach(Transform child in transform) {
			Destroy(child.gameObject);
		}
	}
		



}
