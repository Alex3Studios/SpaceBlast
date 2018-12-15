using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public string winner;

	/***********************************************
	 * Keeps this Game Object Alive throughout the *
	 * whole game, even though other scenes are    *
	 * loaded which should destroy the object      *
	 **********************************************/
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}
	// Use this for end game
	/**********************************************
	 * When called, ends the current battle round *
	 * and calls GameOver() which loads the Game  *
	 * Over Scene                                 *
	 *********************************************/
	public void EndGame() {
		GameOver();
	}

	/*************************
	 * Reloads Current Scene *
	 ************************/
	public void RestartCurrentScene() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	/*************************************************
	 * Loads Game Over Menu when the 'best out of 5' *
	 * condition is met                              *
	 ************************************************/
	public void GameOver() {
		SceneManager.LoadScene("GameOverMenu");
	}
}
