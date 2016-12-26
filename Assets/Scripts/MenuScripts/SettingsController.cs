using UnityEngine;
using System.Collections;

public class SettingsController {
	public static SettingsController settingsCtrl = null;

	private LocalDataController localDataCtrl;

	public int maxFutureDistance;
	public int shortRadius;
	public int longRadius;
	public int speed;

	public SettingsController () {
		localDataCtrl = new LocalDataController ();
		readSettings ();
	}

	public void readSettings() {
		SettingsModel settings = localDataCtrl.readSettings();
		if (settings != null) {
			maxFutureDistance = settings.maxFutureDistance;
			shortRadius = settings.shortRadius;
			longRadius = settings.longRadius;
			speed = settings.speed;
		}
	}

	public void saveSettings() {
		localDataCtrl.updateSettings ( maxFutureDistance,  shortRadius,  longRadius,  speed);
		readSettings ();
	}
		
}
