using UnityEngine;
using System.Collections;

public class SettingsViewController : MonoBehaviour {
	public static SettingsViewController settingsViewCtrl = null;

	void Start () {
		if (settingsViewCtrl == null) {
			settingsViewCtrl = new SettingsViewController ();
		}
	}
	

	public bool isDataControllerNull() {
		return DataController.dataCtrl != null;
	}

	// Getters
	public float getCurrentDistance() {
		return DataController.dataCtrl.currentDistance;
	}

	public float getLongAreaDetectorRadius() {
		return DataController.dataCtrl.longAreaDetectorRadius;
	}

	public float getShortAreaDetectorRadius() {
		return DataController.dataCtrl.shortAreaDetectorRadius;
	}

	public float getAirplaneSpeed() {
		return DataController.dataCtrl.airplaneSpeed;
	}


	// Setters 
	public void setCurrentDistance(float currentDistance) {
		DataController.dataCtrl.currentDistance = currentDistance;
	}

	public void setLongAreaDetectorRadius(float longAreaDetectorRadius) {
		DataController.dataCtrl.longAreaDetectorRadius = longAreaDetectorRadius;
	}

	public void setShortAreaDetectorRadius(float shortAreaDetectorRadius) {
		DataController.dataCtrl.shortAreaDetectorRadius = shortAreaDetectorRadius;
	}

	public void setAirplaneSpeed(float airplaneSpeed) {
		DataController.dataCtrl.airplaneSpeed = airplaneSpeed;
	}
}
