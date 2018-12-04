using UnityEngine;
using System.Collections;

public class PlayerTwo : MonoBehaviour {

	public int health = 1000;

	public GameObject deathEffect;

	public void TakeDamage(int damage) {
		health -= damage;

		if(health <= 0) {
			Debug.Log("Dead");
			Die();
		}
	}

	void Die() {
		//Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
