using UnityEngine;
using System.Collections;
using NUnit.Framework;

public class TestSettingsData {

	private static string PATH_TEST = "/settings_test.dat";

	// Test 1: Assert Settings Read
	[Test]
	public void AssertSettingsRead() {

		SettingsStorage storage = new SettingsStorage (PATH_TEST);

		SettingsModel settingsModel = new SettingsModel (5, 5, 10, 500);

		// Update the settings in file
		storage.updateSettings(settingsModel);


		// Read settings in file
		SettingsModel settingsSaved = storage.readSettings ();

		Assert.That (settingsModel.maxFutureDistance == settingsSaved.maxFutureDistance);
		Assert.That (settingsModel.longRadius == settingsSaved.longRadius);
		Assert.That (settingsModel.shortRadius == settingsSaved.shortRadius);
		Assert.That (settingsModel.speed == settingsSaved.speed);
	}

	// Test 2: Assert Settings Updated
	[Test]
	public void AssertSettingsUpdated() {

		SettingsStorage storage = new SettingsStorage (PATH_TEST);

		SettingsModel settingsModel = new SettingsModel (5, 5, 10, 500);

		// Update the settings in file
		storage.updateSettings(settingsModel);

		settingsModel.maxFutureDistance = 1000;
		settingsModel.shortRadius = 1200;
		settingsModel.longRadius = 1233;
		settingsModel.speed = 400;

		// Update the settings in file
		storage.updateSettings(settingsModel);

		// Read settings in file
		SettingsModel settingsSaved = storage.readSettings ();

		Assert.That (settingsModel.maxFutureDistance == settingsSaved.maxFutureDistance);
		Assert.That (settingsModel.longRadius == settingsSaved.longRadius);
		Assert.That (settingsModel.shortRadius == settingsSaved.shortRadius);
		Assert.That (settingsModel.speed == settingsSaved.speed);
	}
}
