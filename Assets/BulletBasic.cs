﻿using UnityEngine;
using System.Collections;

public class BulletBasic : MonoBehaviour {

	public float speed = 20f;
	public int damage = 350;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb.velocity = transform.right * speed;
	}

	void onTriggerEnter2D(Collider2D hitInfo) {
		PlayerOne player = hitInfo.GetComponent<PlayerOne>();
		if(player != null) {
			player.TakeDamage(damage);
		}
		Destroy(gameObject);
	}
}
