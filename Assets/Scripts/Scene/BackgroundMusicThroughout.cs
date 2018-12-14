using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicThroughout : MonoBehaviour {

	// Makes Music never stop
	void Awake() {
		GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
		if(objs.Length > 1) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}
}
