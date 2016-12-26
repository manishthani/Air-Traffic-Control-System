﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour{
	public static UIController UICtrl;

	private GameObject collisionScrollView;
	private GameObject warningPanel;
	private GameObject speedSlider;
	private GameObject airplaneMiniatureImage;
	private GameObject airplaneIcon;

	private Hashtable airplanesHash;
	// Use this for initialization
	void Start () {
		if (UICtrl == null) {
			UICtrl = GameObject.FindGameObjectWithTag ("UICtrl").GetComponent<UIController> ();
		}

		// This should not be in the controller!
		collisionScrollView = transform.FindChild ("CollisionInfoScrollView").FindChild ("ViewPort").FindChild ("Content").gameObject;

			
		warningPanel = transform.FindChild ("WarningPanel").gameObject;
		speedSlider = transform.FindChild ("SpeedSlider").gameObject;
		airplaneMiniatureImage = transform.FindChild ("AirplaneMiniatureImage").gameObject;
		airplaneIcon = airplaneMiniatureImage.transform.Find("AirplaneIcon").gameObject;

		airplanesHash = new Hashtable ();
		hideWarningPanel ();

	}

	public void addCollisionInfo (string description) {
		collisionScrollView.GetComponent<Text>().text += description + "\n\n";
		RectTransform rect = collisionScrollView.GetComponent<RectTransform> ();
		rect.offsetMin = new Vector2 (rect.offsetMin.x, rect.offsetMin.y - 50.0f);
	}

	public void showWarningPanel() {
		warningPanel.SetActive (true);
	}

	public void hideWarningPanel() {
		warningPanel.SetActive (false);
	}

	public void eraseInfoInWarningPanel() {
		warningPanel.transform.FindChild ("TextDescription").GetComponent<Text> ().text = string.Empty;
	}

	public void addWarningPanelInfo(string description) {
		warningPanel.transform.FindChild ("TextDescription").GetComponent<Text> ().text = description;
		addCollisionInfo (description.ToUpper ());

	}

	public void confirmExitButtonEvent() {
		GameMaster.gm.loadResultScene ();
	}

	public float getSpeedSliderValue() {
		return speedSlider.GetComponent<Slider> ().value;
	}

	public void updateAirplaneInMiniatureImage (string id, Vector3 position, Color color, Vector2 waypoint) {
		RectTransform rect = airplaneMiniatureImage.GetComponent<RectTransform> ();
		Vector2 normalizedVector = new Vector2 (((position.x/500.0f) * rect.rect.size.x * 0.95f), ((position.z/500.0f) * rect.rect.size.y) * 0.95f);
		GameObject airplaneInstance = airplanesHash [id] as GameObject;

		Vector3 diff = normalizedVector - waypoint;
		diff.Normalize();
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		airplaneInstance.transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90.0f);

		airplaneInstance.GetComponent<RectTransform> ().anchoredPosition = normalizedVector;

		airplaneInstance.GetComponent<CanvasRenderer> ().SetColor(color);


	}

	public void addAirplaneInMiniatureImage (string id, Vector3 position) {
		
		GameObject airplaneInstance = Instantiate (airplaneIcon, Vector3.zero, Quaternion.identity) as GameObject;
		airplaneInstance.transform.SetParent(airplaneMiniatureImage.transform);
		airplaneInstance.SetActive (true);
		airplanesHash.Add (id, airplaneInstance);
	}

	public void onAccelerationSliderValueChange() {
		speedSlider.transform.Find ("Panel").Find ("Text").GetComponent<Text> ().text = speedSlider.GetComponent<Slider> ().value.ToString();
	}
}