using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DataController : MonoBehaviour {
	public static DataController dataCtrl = null;
	private float currentDistance = 1.0f;
	public ArrayList airplanes;

	public float getCurrentDistance () {
		return currentDistance;
	}

	public void setCurrentDistance (float value){
		currentDistance = value;
	} 

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
