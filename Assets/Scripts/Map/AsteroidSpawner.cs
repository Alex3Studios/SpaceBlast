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

	// Use this for initialization
	void Start () {
		StartCoroutine(Spawner());
	}
	
	// Update is called once per frame
	void Update () {
		spawnWait = Random.Range(spawnMinWait, spawnMaxWait);
	}

	IEnumerator Spawner() {
		yield return new WaitForSeconds(startWait);

		while(true) {
			// Randomize whether to spawn on x or y axis, 0 = x, 1 = y
			// This is so as to keep the space used to a minimun but still
			// spawning the asteroids off screen
			
			int whichAxis = Random.Range(0,1);
			float x = 0;
			float y = 0;
			float xLeft = -32;
			float yTop = 15;

			if(whichAxis == 0) {
				x = Random.Range(-size.x / 2, size.x / 2);
				y = yTop;
			}
			else {
				x = xLeft;
				y = Random.Range(-size.y / 2, size.y / 2);
			}

			Vector2 pos = new Vector2(x, y);
			Instantiate(AsteroidPrefab, pos, Quaternion.identity);
			yield return new WaitForSeconds(spawnWait);
		}
	}

}
