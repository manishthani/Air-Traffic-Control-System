using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DataController : MonoBehaviour {
	public static DataController dataCtrl = null;
	public float currentDistance = 1.0f;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		if (dataCtrl == null) {
			dataCtrl = new DataController ();
		}
	}
}
