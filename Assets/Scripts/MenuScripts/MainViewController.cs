using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainViewController : MonoBehaviour {
	public static MainViewController mainCtrl = null;

	private GameObject mainPanel;
	private GameObject settingsPanel;
	private GameObject showAirplanesPanel;
	private GameObject insertAirplanePanel;

	// Use this for initialization
	void Start () {
		if (mainCtrl == null) {
			mainCtrl = new MainViewController ();
		}
		mainPanel = transform.Find (Constants.MAINPANEL).gameObject;
		settingsPanel = transform.Find (Constants.SETTINGSPANEL).gameObject;

		Transform airplanePanels = transform.Find (Constants.AIRPLANEPANELS);
		showAirplanesPanel = airplanePanels.Find (Constants.SHOWAIRPLANEPANEL).gameObject;
		insertAirplanePanel = airplanePanels.Find (Constants.INSERTAIRPLANEPANEL).gameObject;
	}
	
	public void showSettingsPanel() {
		mainPanel.SetActive (false);
		settingsPanel.SetActive (true);
	}

	public void showMainPanel() {
		mainPanel.SetActive (true);
		settingsPanel.SetActive (false);
		showAirplanesPanel.SetActive (false);
		insertAirplanePanel.SetActive (false);
	}

	public void ShowAirplanesPanel() {
		mainPanel.SetActive (false);
		insertAirplanePanel.SetActive (false);
		showAirplanesPanel.SetActive (true);
	}

	public void showInsertAirplanePanel() {
		// Refresh Airplane Trajectories before showing
		showAirplanesPanel.SetActive (false);
		insertAirplanePanel.SetActive (true);
		insertAirplanePanel.GetComponent<InsertAirplaneView> ().trajectory.GetComponent<AirplaneTrajectoriesView> ().clean ();

	}

	public void loadVisualizationScene() {
		LoadScenes.loadMainScene ();
	}
}
