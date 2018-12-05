using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour {

	public float maxThrust;
	public float maxTorque;
	public Rigidbody2D rb;

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
}
