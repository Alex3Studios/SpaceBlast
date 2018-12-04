using UnityEngine;
using System.Collections;
using Rewired;

public class PlayerTwoShooting : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletPrefab;
	private Player player2;

	void Awake() {
		player2 = ReInput.players.GetPlayer(1);
	}
	
	// Update is called once per frame
	void Update () {
		PlayerTwoController pm = GetComponent<PlayerTwoController>();
		if(player2.GetButtonDown("Shoot")) {
			Shoot();
			pm.Recoil();
		}
	}

	void Shoot() {
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
