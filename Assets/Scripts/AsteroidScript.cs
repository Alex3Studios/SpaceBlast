using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour {

	public float maxThrust;
	public float maxTorque;
	public Rigidbody2D rb;
	public int asteroidSize;	// 3 = Large, 2 = Medium, 1 = Small
	public GameObject asteroidMedium;
	public GameObject asteroidSmall;

	// Use this for initialization
	void Start () {
		//Add a random amount of torque and thrust to the asteroid
		Vector2 thrust =  new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
		float torque = Random.Range(-maxTorque, maxTorque);
		rb.AddForce(thrust);
		rb.AddTorque(torque);
	}
	
	// Update is called once per frame
	void Update () {
		Physics2D.IgnoreLayerCollision(9,10);
	}

	void OnTriggerEnter2D(Collider2D other) {
		// Check if it's a bullet
		if(other.CompareTag("bullet")) {
			Debug.Log("Hit by " + other.name);
			// Destroy the bullet
			Destroy(other.gameObject);
			// Check the size of the asteroid and spawn in the next smaller size
			if(asteroidSize == 3) {
				// Spawn two medium asteroids
				Instantiate(asteroidMedium, transform.position, transform.rotation);
				Instantiate(asteroidMedium, transform.position, transform.rotation);
			}
			else if(asteroidSize == 2) {
				// Spawn two small asteroids
				Instantiate(asteroidSmall, transform.position, transform.rotation);
				Instantiate(asteroidSmall, transform.position, transform.rotation);
			}
			// Remove the asteroid
			Destroy(gameObject);
		}
	}
}
