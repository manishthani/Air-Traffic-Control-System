using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateSliderText : MonoBehaviour {

	public Text textField;
	private Slider slider; 
	void Start() {
		slider = gameObject.GetComponent<Slider> ();
	}

	void Update() {
		if (DataController.dataCtrl != null) {
			if (transform.parent.name == "MaximumFutureAirplaneDistance") {
				slider.value = DataController.dataCtrl.currentDistance;
			} else if (transform.parent.name == "LongDetectorRadius") {
				slider.value = DataController.dataCtrl.longAreaDetectorRadius;
			} else if (transform.parent.name == "ShortDetectorRadius") {
				slider.value = DataController.dataCtrl.shortAreaDetectorRadius;
			} else if (transform.parent.name == "AirplaneSpeed") {
				slider.value = DataController.dataCtrl.airplaneSpeed;
			}
		}
	}
		
	public void ValueChangeCheck() {
		float value = gameObject.GetComponent<Slider> ().value;
		textField.text = value.ToString();
		if (transform.parent.name == "MaximumFutureAirplaneDistance") {
			DataController.dataCtrl.currentDistance = slider.value;
		} else if (transform.parent.name == "LongDetectorRadius") {
			DataController.dataCtrl.longAreaDetectorRadius = slider.value;
		} else if (transform.parent.name == "ShortDetectorRadius") {
			DataController.dataCtrl.shortAreaDetectorRadius = slider.value;
		} else if (transform.parent.name == "AirplaneSpeed") {
			DataController.dataCtrl.airplaneSpeed = slider.value;
		}
	}
}
