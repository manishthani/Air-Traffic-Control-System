﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LoadScenes : MonoBehaviour {

	public void loadMainScene() {
		SceneManager.LoadScene ("MainScene");
	}

	public void loadMenuScene() {
		SceneManager.LoadScene ("Menu");
	}
}
