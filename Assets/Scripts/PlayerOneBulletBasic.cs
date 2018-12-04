using UnityEngine;
using System.Collections;

public class PlayerOneBulletBasic : MonoBehaviour {

	public float speed = 20f;
	public int damage = 350;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb.velocity = transform.right * speed;
	}

	void OnTriggerEnter2D(Collider2D hitInfo) {
		PlayerOne playerOne = hitInfo.GetComponent<PlayerOne>();
		PlayerTwo playerTwo = hitInfo.GetComponent<PlayerTwo>();
		
		if(playerTwo != null) {
			playerTwo.TakeDamage(damage);
			Destroy(gameObject);
		}
		if(playerOne == null) {
			Destroy(gameObject);
		}
	}
}
