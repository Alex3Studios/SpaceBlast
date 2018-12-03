using UnityEngine;
using System.Collections;

public class PlayerOne : MonoBehaviour {

	public int health = 1000;

	public GameObject deathEffect;

	public void TakeDamage(int damage) {
		health -= damage;

		if(health <= 0) {
			Die();
		}
	}

	void Die() {
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
