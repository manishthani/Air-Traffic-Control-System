using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LoadScenes{

	public static void loadMainScene() {
		SceneManager.LoadScene ("MainScene");
	}

	public static void loadMenuScene() {
		SceneManager.LoadScene ("Menu");
	}

	public static void loadResultScene() {
		VisualizationDataController.vdCtrl.setTotalTime();
		SceneManager.LoadScene ("Results");
	}
}
