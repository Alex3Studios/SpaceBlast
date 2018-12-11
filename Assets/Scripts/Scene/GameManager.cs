using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	bool gameHasEnded = false;

	// Use this for end game
	public void EndGame() {
		if(gameHasEnded == false) {
			gameHasEnded = true;
			Debug.Log("GAME OVER");
			Restart();
		}
	}

	void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
