using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DataController : MonoBehaviour {
	public static DataController dataCtrl = null;
	public float currentDistance = 1.0f;
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
