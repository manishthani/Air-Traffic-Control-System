using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LoadMainScene : MonoBehaviour {

	public void loadScene() {
		SceneManager.LoadScene ("MainScene");
	}
}
