using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsView : MonoBehaviour {

	public Text textField;
	private Slider slider; 

	void Start() {
		slider = gameObject.GetComponent<Slider> ();
	}

	void Update() {
		if (SettingsViewController.settingsViewCtrl.isDataControllerNull()) {
			if (transform.parent.name == "MaximumFutureAirplaneDistance") {
				slider.value = SettingsViewController.settingsViewCtrl.getCurrentDistance ();
			} else if (transform.parent.name == "LongDetectorRadius") {
				slider.value = SettingsViewController.settingsViewCtrl.getLongAreaDetectorRadius ();
			} else if (transform.parent.name == "ShortDetectorRadius") {
				slider.value = SettingsViewController.settingsViewCtrl.getShortAreaDetectorRadius ();
			} else if (transform.parent.name == "AirplaneSpeed") {
				slider.value = SettingsViewController.settingsViewCtrl.getAirplaneSpeed ();
			}
		}
	}
		
	public void ValueChangeCheck() {
		textField.text = slider.value.ToString();

		if (transform.parent.name == "MaximumFutureAirplaneDistance") {
			SettingsViewController.settingsViewCtrl.setCurrentDistance(slider.value);
		} else if (transform.parent.name == "LongDetectorRadius") {
			SettingsViewController.settingsViewCtrl.setLongAreaDetectorRadius (slider.value);
		} else if (transform.parent.name == "ShortDetectorRadius") {
			SettingsViewController.settingsViewCtrl.setShortAreaDetectorRadius (slider.value);
		} else if (transform.parent.name == "AirplaneSpeed") {
			SettingsViewController.settingsViewCtrl.setAirplaneSpeed (slider.value);
		}
	}
}
