using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DataController : MonoBehaviour {
	public static DataController dataCtrl = null;
	public float currentDistance = 1.0f;
	public float airplaneSpeed = 600.0f;
	public float longAreaDetectorRadius = 6.0f;
	public float shortAreaDetectorRadius = 1.0f;

	public ArrayList airplanes;

	void Awake() {
		DontDestroyOnLoad(this);
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}

	}

	// Use this for initialization
	void Start () {
		if (dataCtrl == null) {
			dataCtrl = new DataController ();
		}
	}
}
