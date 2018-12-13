using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public string winner;

	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}
	// Use this for end game
	public void EndGame() {
		GameOver();
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
