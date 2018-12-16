using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool gameIsPaused = false;
	public GameObject pauseMenuUI;
	public GameObject helpMenuUI;
	
	/**************************************************************
	 * Loads Play Menu Panel when 'Start'/'Esc' button is pressed *
	 * If the game is paused then it resumes the game when the    *
	 * button is pressed, and if not then it brings up the panel  *
	 *************************************************************/
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

	/***************************************************
	 * Resumes gameplay and sets the time back in play *
	 **************************************************/
	public void Resume() {
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		gameIsPaused = false;
	} 

	/*********************************************
	 * Pauses gameplay and sets the time to stop *
	 ********************************************/
	void Pause() {
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		gameIsPaused = true;
	}

	/**************************************************************
	 * Deactivates pause menu and brings up the help menu instead *
	 *************************************************************/
	public void Help() {
		pauseMenuUI.SetActive(false);
		helpMenuUI.SetActive(true);
	}

	/************************************************
	 * Leaves help menu and goes back to pause menu *
	 ***********************************************/
	public void quitHelp() {
		helpMenuUI.SetActive(false);
		pauseMenuUI.SetActive(true);
	}

	/******************************************************
	 * Restart time, leave pause Menu and load Start Menu *
	 *****************************************************/
	public void quitGame() {
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		gameIsPaused = false;
		SceneManager.LoadScene("StartMenu");
	}
}
