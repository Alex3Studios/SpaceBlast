using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

	// Called when Play Again button is pressed

	void Start () {
		var winnertext = GameObject.FindGameObjectWithTag("winnertext");
		winnertext.GetComponent<UnityEngine.UI.Text>().text = "Winner: " + FindObjectOfType<GameManager>().winner;
	}
	public void PlayAgain () {
		SceneManager.LoadScene("Main");
	}

	// Called when Main Menu button is pressed
	public void MainMenu () {
		SceneManager.LoadScene("StartMenu");
	}
}
