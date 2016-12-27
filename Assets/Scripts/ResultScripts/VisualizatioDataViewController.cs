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
		Text visualizationTimeText = visualizationTimePanel.transform.Find (Constants.VISUALIZATIONTIMEVALUE).GetComponent<Text> ();
		Text totalNumberConflictsText = totalNumberConflictsPanel.transform.Find (Constants.TOTALNUMBERCONFLICTSVALUE).GetComponent<Text> ();
		Text totalNumberCollisionText = totalNumberCollisionPanel.transform.Find (Constants.TOTALNUMBERCOLLISIONVALUE).GetComponent<Text> ();
		Text  airplanesArrivedToDestinationText = airplanesArrivedToDestinationPanel.transform.Find (Constants.AIRPLANESARRIVEDTODESTINATIONVALUE).GetComponent<Text> ();
		Text airplanesEnRouteText = airplanesEnRoutePanel.transform.Find (Constants.AIRPLANESENROUTEVALUE).GetComponent<Text> ();

		visualizationTimeText.text = VisualizationDataController.vdCtrl.getTotalTime().ToString();
		airplanesArrivedToDestinationText.text = VisualizationDataController.vdCtrl.totalAirplanesArrived.ToString();
		airplanesEnRouteText.text = VisualizationDataController.vdCtrl.totalAirplanesEnRoute.ToString();
		int shortConflicts = VisualizationDataController.vdCtrl.totalShortConflicts;
		int longConflicts = VisualizationDataController.vdCtrl.totalLongConflicts;
		totalNumberConflictsText.text = "Long Conflicts: " + longConflicts + " | Short Conflicts: " + shortConflicts + " | Total: " + (shortConflicts + longConflicts);
		totalNumberCollisionText.text = VisualizationDataController.vdCtrl.totalCollisions.ToString ();
	
	}
	
	public void loadMenuScene() {
		LoadScenes.loadMenuScene ();
	}
}
