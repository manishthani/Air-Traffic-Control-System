using UnityEngine;
using System.Collections;

public class SettingsViewController : MonoBehaviour {
	public static SettingsViewController settingsViewCtrl = null;

	void Awake () {
		if (settingsViewCtrl == null) {
			settingsViewCtrl = new SettingsViewController ();
			SettingsDataController.settingsDataCtrl = new SettingsDataController ();

		}
	}
	

	public bool isDataControllerNull() {
		return DataController.dataCtrl != null;
	}

	// Getters
	public float getCurrentDistance() {
		return SettingsDataController.settingsDataCtrl.settings.maxFutureDistance;
	}

	public float getLongAreaDetectorRadius() {
		return SettingsDataController.settingsDataCtrl.settings.longRadius;
	}

	public float getShortAreaDetectorRadius() {
		return SettingsDataController.settingsDataCtrl.settings.shortRadius;
	}

	public float getAirplaneSpeed() {
		return SettingsDataController.settingsDataCtrl.settings.speed;
	}


	// Setters 
	public void setCurrentDistance(float currentDistance) {
		SettingsDataController.settingsDataCtrl.settings.maxFutureDistance = Mathf.FloorToInt( currentDistance);
		DataController.dataCtrl.currentDistance = currentDistance;
	}

	public void setLongAreaDetectorRadius(float longAreaDetectorRadius) {
		SettingsDataController.settingsDataCtrl.settings.longRadius = Mathf.FloorToInt(longAreaDetectorRadius);
		DataController.dataCtrl.longAreaDetectorRadius = longAreaDetectorRadius;
	}

	public void setShortAreaDetectorRadius(float shortAreaDetectorRadius) {
		SettingsDataController.settingsDataCtrl.settings.shortRadius = Mathf.FloorToInt(shortAreaDetectorRadius);
		DataController.dataCtrl.shortAreaDetectorRadius = shortAreaDetectorRadius;
	}

	public void setAirplaneSpeed(float airplaneSpeed) {
		SettingsDataController.settingsDataCtrl.settings.speed = Mathf.FloorToInt(airplaneSpeed);
		DataController.dataCtrl.airplaneSpeed = airplaneSpeed;
	}

	public void acceptButtonEvent() {
		SettingsDataController.settingsDataCtrl.saveSettings ();
	}

}
