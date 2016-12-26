using UnityEngine;
using System.Collections;

public class SettingsViewController : MonoBehaviour {
	public static SettingsViewController settingsViewCtrl = null;

	void Awake () {
		if (settingsViewCtrl == null) {
			settingsViewCtrl = new SettingsViewController ();
			SettingsController.settingsCtrl = new SettingsController ();

		}
	}
	

	public bool isDataControllerNull() {
		return DataController.dataCtrl != null;
	}

	// Getters
	public float getCurrentDistance() {
		return SettingsController.settingsCtrl.maxFutureDistance;
	}

	public float getLongAreaDetectorRadius() {
		return SettingsController.settingsCtrl.longRadius;
	}

	public float getShortAreaDetectorRadius() {
		return SettingsController.settingsCtrl.shortRadius;
	}

	public float getAirplaneSpeed() {
		return SettingsController.settingsCtrl.speed;
	}


	// Setters 
	public void setCurrentDistance(float currentDistance) {
		SettingsController.settingsCtrl.maxFutureDistance = Mathf.FloorToInt( currentDistance);
		DataController.dataCtrl.currentDistance = currentDistance;
	}

	public void setLongAreaDetectorRadius(float longAreaDetectorRadius) {
		SettingsController.settingsCtrl.longRadius = Mathf.FloorToInt(longAreaDetectorRadius);
		DataController.dataCtrl.longAreaDetectorRadius = longAreaDetectorRadius;
	}

	public void setShortAreaDetectorRadius(float shortAreaDetectorRadius) {
		SettingsController.settingsCtrl.shortRadius = Mathf.FloorToInt(shortAreaDetectorRadius);
		DataController.dataCtrl.shortAreaDetectorRadius = shortAreaDetectorRadius;
	}

	public void setAirplaneSpeed(float airplaneSpeed) {
		SettingsController.settingsCtrl.speed = Mathf.FloorToInt(airplaneSpeed);
		DataController.dataCtrl.airplaneSpeed = airplaneSpeed;
	}

	public void acceptButtonEvent() {
		SettingsController.settingsCtrl.saveSettings ();
	}

}
