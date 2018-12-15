using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	/*************************************************************
	 * Loads CountDown Scene when 'Start Game' button is pressed *
	 ************************************************************/
	public void StartGame () {
		SceneManager.LoadScene("CountDown");
	}
}
