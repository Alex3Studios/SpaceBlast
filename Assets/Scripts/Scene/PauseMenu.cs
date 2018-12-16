using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool gameIsPaused = false;
	public GameObject pauseMenuUI;
	public GameObject helpMenuUI;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			if(gameIsPaused) {
				Resume();
			}
			else {
				Pause();
			}
		}
	}

	public void Resume() {
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		gameIsPaused = false;
	} 

	void Pause() {
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		gameIsPaused = true;
	}

	public void Help() {
		//Debug.Log("Help is selected");
		pauseMenuUI.SetActive(false);
		helpMenuUI.SetActive(true);
	}

	public void quitHelp() {
		helpMenuUI.SetActive(false);
		pauseMenuUI.SetActive(true);
	}

	public void quitGame() {
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		gameIsPaused = false;
		SceneManager.LoadScene("StartMenu");
	}
}
