using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainController : MonoBehaviour {
	private GameObject mainPanel;
	private GameObject settingsPanel;
	private GameObject editVisualizationPanel;
	private GameObject addAirplanePanel;
	// Use this for initialization
	void Start () {
		mainPanel = transform.Find ("MainPanel").gameObject;
		settingsPanel = transform.Find ("SettingsPanel").gameObject;
		editVisualizationPanel = transform.Find ("EditVisualizationPanel").gameObject;
		addAirplanePanel = transform.Find ("AddAirplanePanel").gameObject;
	}
	
	public void showSettingsPanel() {
		mainPanel.SetActive (false);
		settingsPanel.SetActive (true);
	}

	public void showMainPanel() {
		mainPanel.SetActive (true);
		settingsPanel.SetActive (false);
		editVisualizationPanel.SetActive (false);
		addAirplanePanel.SetActive (false);
	}

	public void showEditVisualizationPanel() {
		mainPanel.SetActive (false);
		editVisualizationPanel.SetActive (true);
	}

	public void showAddAirplanePanel() {
		editVisualizationPanel.SetActive (false);
		addAirplanePanel.SetActive (true);
	}
}
