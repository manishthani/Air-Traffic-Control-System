﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	public static UIController UICtrl;

	private Text collisionScrollViewText;
	private GameObject warningPanel;
	// Use this for initialization
	void Start () {
		if (UICtrl == null) {
			UICtrl = GameObject.FindGameObjectWithTag ("UICtrl").GetComponent<UIController> ();
		}
		collisionScrollViewText = gameObject.transform.FindChild ("CollisionInfoScrollView").FindChild ("ViewPort").FindChild ("Content").GetComponent<Text>();

		warningPanel = gameObject.transform.FindChild ("WarningPanel").gameObject;
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
}
