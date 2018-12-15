using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicThroughout : MonoBehaviour {

	/**************************************************************
	 * Loops through all objects tagged with 'music'. If they are *
	 * more than one then the same scene has loaded again. That's *
	 * why any object after the first with the tag is destroyed,  *
	 * e.g. so that there won't be two existing objects playing   *
	 * the music at the same time. The last one, is then kept     *
	 * alive to carry on out into the rest of the game            *
	 *************************************************************/
	void Awake() {
		GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
		if(objs.Length > 1) {
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}
}
