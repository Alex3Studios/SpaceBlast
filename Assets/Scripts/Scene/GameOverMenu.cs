using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

	/**************************************************************
	 * Loops through all objects tagged with 'winnertext'         *
	 * (because there are 3 textboxes for that) and changes       *
	 * the final "winner text" into the player that won the round *
	 *************************************************************/
	void Start () {
		var winnertext = GameObject.FindGameObjectsWithTag("winnertext");
		foreach(var textor in winnertext){
			textor.GetComponent<UnityEngine.UI.Text>().text = "Winner: " + FindObjectOfType<GameManager>().winner;
		}
	}

	/*************************************************************
	 * Loads CountDown Scene when 'Play Again' button is pressed *
	 ************************************************************/
	public void PlayAgain () {
		SceneManager.LoadScene("CountDown");
	}

	/*******************************************************
	 * Loads Start Menu when 'Main Menu' button is pressed *
	 ******************************************************/
	public void MainMenu () {
		SceneManager.LoadScene("StartMenu");
	}
}
