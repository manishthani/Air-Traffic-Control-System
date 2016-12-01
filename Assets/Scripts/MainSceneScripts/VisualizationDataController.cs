using UnityEngine;
using System.Collections;

public class  VisualizationDataController : MonoBehaviour {

	public static VisualizationDataController vdCtrl = null;

	public float visualizationTime;
	public int totalConflicts;
	public int totalCollisions;
	public int totalAirplanesArrived;
	public int totalAirplanesEnRoute;


	void Awake() {
		DontDestroyOnLoad(this);
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}

	}

	// Use this for initialization
	void Start () {
		if (vdCtrl == null) {
			vdCtrl = new VisualizationDataController ();
		}
	}
}
