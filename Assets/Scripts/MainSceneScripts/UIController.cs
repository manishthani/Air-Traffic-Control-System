using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour{
	public static UIController UICtrl;

	private Text collisionScrollViewText;
	private GameObject warningPanel;
	private GameObject editVisualizationPanel;
	// Use this for initialization
	void Start () {
		if (UICtrl == null) {
			UICtrl = GameObject.FindGameObjectWithTag ("UICtrl").GetComponent<UIController> ();
		}

		// This should not be in the controller!
		collisionScrollViewText = gameObject.transform.FindChild ("CollisionInfoScrollView").FindChild ("ViewPort").FindChild ("Content").GetComponent<Text>();

		editVisualizationPanel = transform.FindChild ("EditVisualizationPanel").gameObject;
			
		warningPanel = transform.FindChild ("WarningPanel").gameObject;
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

	public void showEditVisualizationPanel() {
		
		editVisualizationPanel.SetActive (true);
		Time.timeScale = 0;
	}

	public void hideEditVisualizationPanel() {
		editVisualizationPanel.SetActive (false);
		Time.timeScale = 1;
	}

	public void addWarningPanelInfo(string description) {
		warningPanel.transform.FindChild ("TextDescription").GetComponent<Text> ().text = description;
	}
}
