using UnityEngine;
using System.Collections;
using Rewired;

public class PlayerOne : MonoBehaviour {

	public int health = 1000;
	public Transform firePoint;
	public GameObject bulletPrefab;
	private Player player1;
	public GameObject deathEffect;

	void Awake() {
             player1 = ReInput.players.GetPlayer(0);
     }
 
     //Update Function
    void Update()
    {
        //Move
        //float Move = Input.GetAxis ("Horizontal");
        //float MoveVertical = Input.GetAxis ("Vertical");
        float MoveX = player1.GetAxis("RotateX");
        float MoveY = player1.GetAxis("RotateY");
        float heading = Mathf.Atan2(MoveY, MoveX);

        transform.rotation = Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg);

		if(player1.GetButtonDown("Shoot")) {
			Shoot();
			Recoil(7);
		}
		if(player1.GetButtonDown("PowerUp")) {
			GameObject weaponmanagerObject = GameObject.Find("PlayerOneWeaponSlot");
			WeaponManager wm = weaponmanagerObject.GetComponent<WeaponManager>();
			int recoil = wm.Shoot();
			//pm.Recoil(recoil);

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
