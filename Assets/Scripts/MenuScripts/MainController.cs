using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainController : MonoBehaviour {
	public static MainController mainCtrl = null;

	private GameObject mainPanel;
	private GameObject settingsPanel;
	private GameObject showAirplanesPanel;
	private GameObject addAirplanePanel;

	// Use this for initialization
	void Start () {
		if (mainCtrl == null) {
			mainCtrl = new MainController ();
		}
		mainPanel = transform.Find ("MainPanel").gameObject;
		settingsPanel = transform.Find ("SettingsPanel").gameObject;
		showAirplanesPanel = transform.Find("AirplanePanels").Find ("ShowAirplanesPanel").gameObject;
		addAirplanePanel = transform.Find("AirplanePanels").Find ("AddAirplanePanel").gameObject;
	}
	
	public void showSettingsPanel() {
		mainPanel.SetActive (false);
		settingsPanel.SetActive (true);
	}

	public void showMainPanel() {
		mainPanel.SetActive (true);
		settingsPanel.SetActive (false);
		showAirplanesPanel.SetActive (false);
		addAirplanePanel.SetActive (false);
	}

	public void ShowAirplanesPanel() {
		mainPanel.SetActive (false);
		addAirplanePanel.SetActive (false);
		showAirplanesPanel.SetActive (true);
	}

	public void showAddAirplanePanel() {
		showAirplanesPanel.SetActive (false);
		addAirplanePanel.SetActive (true);
	}
}
