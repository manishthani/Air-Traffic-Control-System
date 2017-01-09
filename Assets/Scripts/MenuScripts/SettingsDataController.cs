using UnityEngine;
using System.Collections;

public class SettingsDataController {
	public static SettingsDataController settingsDataCtrl = null;

	private static string PATH_SETTINGS = "/settings.dat";
	private FileStorage settingsStorage;

	public SettingsModel settings;

	public SettingsDataController () {
		settingsStorage = new SettingsStorage (PATH_SETTINGS);
		settings = new SettingsModel ();
		readSettings ();
	}

	public void readSettings() {
		SettingsModel savedSettings = ((SettingsStorage)settingsStorage).readSettings();
		if (settings != null) {
			settings.maxFutureDistance = savedSettings.maxFutureDistance;
			settings.shortRadius = savedSettings.shortRadius;
			settings.longRadius = savedSettings.longRadius;
			settings.speed = savedSettings.speed;
		}
	}

	public void saveSettings() {
		((SettingsStorage)settingsStorage).updateSettings ( settings);
		readSettings ();
	}
		
}
