using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour{
	public static UIController UICtrl;

	private Text collisionScrollViewText;
	private GameObject warningPanel;
	private GameObject speedSlider;
	// Use this for initialization
	void Start () {
		if (UICtrl == null) {
			UICtrl = GameObject.FindGameObjectWithTag ("UICtrl").GetComponent<UIController> ();
		}

		// This should not be in the controller!
		collisionScrollViewText = gameObject.transform.FindChild ("CollisionInfoScrollView").FindChild ("ViewPort").FindChild ("Content").GetComponent<Text>();

			
		warningPanel = transform.FindChild ("WarningPanel").gameObject;
		speedSlider = transform.FindChild ("SpeedSlider").gameObject;
		hideWarningPanel ();

	}

	public void addCollisionInfo (string description) {
		collisionScrollViewText.text += description + "\n";
	}

	public void showWarningPanel() {
		warningPanel.SetActive (true);
	}

	public void hideWarningPanel() {
		warningPanel.SetActive (false);
	}
		
	public void addWarningPanelInfo(string description) {
		warningPanel.transform.FindChild ("TextDescription").GetComponent<Text> ().text = description;
	}

	public float getSpeedSliderValue() {
		return speedSlider.GetComponent<Slider> ().value;
	}
}
