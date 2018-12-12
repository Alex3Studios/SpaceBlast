using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	bool gameHasEnded = false;

	// Use this for end game
	public void EndGame() {
		if(gameHasEnded == false) {
			gameHasEnded = true;
			Debug.Log("GAME OVER");
			GameOver();
		}
	}

	// Can be called to restart current scene
	public void RestartCurrentScene() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	// Called when game over 
	public void GameOver() {
		SceneManager.LoadScene("GameOverMenu");
	}
}
