using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VisualizatioDataViewController : MonoBehaviour {

	public GameObject visualizationTimePanel;
	public GameObject totalNumberConflictsPanel;
	public GameObject totalNumberCollisionPanel;
	public GameObject airplanesArrivedToDestinationPanel;
	public GameObject airplanesEnRoutePanel;


	void Start () {
		Text visualizationTimeText = visualizationTimePanel.transform.Find ("VisualizationTimeValue").GetComponent<Text> ();
		Text totalNumberConflictsText = totalNumberConflictsPanel.transform.Find ("TotalNumberConflictsValue").GetComponent<Text> ();
		Text totalNumberCollisionText = totalNumberCollisionPanel.transform.Find ("TotalNumberCollisionValue").GetComponent<Text> ();
		Text  airplanesArrivedToDestinationText = airplanesArrivedToDestinationPanel.transform.Find ("AirplanesArrivedToDestinationValue").GetComponent<Text> ();
		Text airplanesEnRouteText = airplanesEnRoutePanel.transform.Find ("AirplanesEnRouteValue").GetComponent<Text> ();

		visualizationTimeText.text = VisualizationDataController.vdCtrl.getTotalTime().ToString();
		airplanesArrivedToDestinationText.text = VisualizationDataController.vdCtrl.totalAirplanesArrived.ToString();
		airplanesEnRouteText.text = VisualizationDataController.vdCtrl.totalAirplanesEnRoute.ToString();
		totalNumberConflictsText.text = VisualizationDataController.vdCtrl.totalConflicts.ToString ();
		totalNumberCollisionText.text = VisualizationDataController.vdCtrl.totalCollisions.ToString ();
	
	}
	
	public void loadMenuScene() {
		LoadScenes.loadMenuScene ();
	}
}
