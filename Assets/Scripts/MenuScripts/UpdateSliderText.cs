using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateSliderText : MonoBehaviour {

	public Text textField;

	void Start() {
		gameObject.GetComponent<Slider> ().value = DataController.dataCtrl.currentDistance;
	}

	public void ValueChangeCheck() {
		float value = gameObject.GetComponent<Slider> ().value;
		textField.text = value.ToString();
		DataController.dataCtrl.currentDistance = value;
	}
}
