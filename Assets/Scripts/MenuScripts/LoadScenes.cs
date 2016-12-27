using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LoadScenes{

	public static void loadMainScene() {
		SceneManager.LoadScene (Constants.MAINSCENE);
	}

	public static void loadMenuScene() {
		SceneManager.LoadScene (Constants.MENU);
	}

	public static void loadResultScene() {
		VisualizationDataController.vdCtrl.setTotalTime();
		SceneManager.LoadScene (Constants.RESULTS);
	}
}
