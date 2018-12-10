using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Called when Start Game button is pressed
	public void StartGame () {
		SceneManager.LoadScene("Main");
	}
}
