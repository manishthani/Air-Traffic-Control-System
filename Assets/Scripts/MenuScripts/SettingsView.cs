using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsView : MonoBehaviour {

	public Text textField;
	private Slider slider; 

	void Start() {
		slider = gameObject.GetComponent<Slider> ();

		if (transform.parent.name == Constants.MAXIMUMFUTUREAIRPLANEDISTANCE) {
			slider.value = SettingsViewController.settingsViewCtrl.getCurrentDistance ();
		} else if (transform.parent.name == Constants.LONGDETECTORRADIUS) {
			slider.value = SettingsViewController.settingsViewCtrl.getLongAreaDetectorRadius ();
		} else if (transform.parent.name == Constants.SHORTDETECTORRADIUS) {
			slider.value = SettingsViewController.settingsViewCtrl.getShortAreaDetectorRadius ();
		} else if (transform.parent.name == Constants.AIRPLANESPEED) {
			slider.value = SettingsViewController.settingsViewCtrl.getAirplaneSpeed ();
		}
	}
		
	public void ValueChangeCheck() {
		textField.text = slider.value.ToString();

		if (transform.parent.name == Constants.MAXIMUMFUTUREAIRPLANEDISTANCE) {
			SettingsViewController.settingsViewCtrl.setCurrentDistance(slider.value);
		} else if (transform.parent.name == Constants.LONGDETECTORRADIUS) {
			SettingsViewController.settingsViewCtrl.setLongAreaDetectorRadius (slider.value);
		} else if (transform.parent.name == Constants.SHORTDETECTORRADIUS) {
			SettingsViewController.settingsViewCtrl.setShortAreaDetectorRadius (slider.value);
		} else if (transform.parent.name == Constants.AIRPLANESPEED) {
			SettingsViewController.settingsViewCtrl.setAirplaneSpeed (slider.value);
		}
	}
}
