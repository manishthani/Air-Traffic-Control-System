using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateSliderText : MonoBehaviour {

	public Text textField;

	void Start() {
		gameObject.GetComponent<Slider> ().value = DataController.dataCtrl.getCurrentDistance();
	}
		
	public void ValueChangeCheck() {
		float value = gameObject.GetComponent<Slider> ().value;
		textField.text = value.ToString();
		DataController.dataCtrl.setCurrentDistance(value);
	}
}
