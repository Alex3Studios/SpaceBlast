using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

	public GameObject AsteroidPrefab;
	public Vector2 center;
	public Vector2 size;
	public float spawnWait;
	public float spawnMaxWait;
	public float spawnMinWait;
	public int startWait;

	/**********************************************
	 * Starts the co-routine Spawner() as soon as *
	 * this object is generated in the scene      *
	 *********************************************/
	void Start () {
		StartCoroutine(Spawner());
	}
	
	/*************************************************
	 * Randomize the waiting time for the next spawn *
	 ************************************************/
	void Update () {
		spawnWait = Random.Range(spawnMinWait, spawnMaxWait);
	}

	/************************************************
	 * Wait for the startWait amount of seconds and *
	 * then keep spawning asteroids while existant. *
	 * The asteroids are spawned outside of the     *
	 * screen-view so that it's more real-like when *
	 * they float inside the screen-view            *
	 ***********************************************/
	IEnumerator Spawner() {
		yield return new WaitForSeconds(startWait);

		while(true) {

			/**************************************
			 * Randomize whether to spawn on x or *
			 * y axis (0 = x, 1 = y). This is so  *
			 * as to keep the space used to a     *
			 * minimun but still spawning the     *
			 * asteroids off screen               *
			 *************************************/
			int whichAxis = Random.Range(0,1);
			float x = 0;
			float y = 0;
			float xLeft = -32;
			float yTop = 15;

			if(whichAxis == 0) {
				// Divide by 2 in consideration to the middle of screen
				x = Random.Range(-size.x / 2, size.x / 2);
				y = yTop;
			}
			else {
				x = xLeft;
				y = Random.Range(-size.y / 2, size.y / 2);
			}

			// Instantiate in new random position and wait
			Vector2 pos = new Vector2(x, y);
			Instantiate(AsteroidPrefab, pos, Quaternion.identity);
			yield return new WaitForSeconds(spawnWait);
		}
	}

}
