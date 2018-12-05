using UnityEngine;
using System.Collections;
using Rewired;

public class PlayerTwo : MonoBehaviour {

	public int health = 1000;
	private Player player2;
	public Transform firePoint;
	public GameObject bulletPrefab;
	public GameObject deathEffect;

	void Awake() {
             player2 = ReInput.players.GetPlayer(1);
     }
 
     //Update Function
    void Update()
    {
        //Move
        //float Move = Input.GetAxis ("Horizontal");
        //float MoveVertical = Input.GetAxis ("Vertical");
        float MoveX = player2.GetAxis("RotateX");
        float MoveY = player2.GetAxis("RotateY");
        float heading = Mathf.Atan2(MoveY, MoveX);

        transform.rotation = Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg);
		if(player2.GetButtonDown("Shoot")) {
			Shoot();
			Recoil(7);
		}
    }

	void Shoot() {
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
    public void Recoil(int recoil) {

            GetComponent<Rigidbody2D>().AddForce(transform.right * -1 * recoil, ForceMode2D.Impulse);
     }

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
