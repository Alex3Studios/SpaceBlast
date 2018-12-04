using UnityEngine;
using System.Collections;
using Rewired;

public class PlayerOneShootingBasic : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletPrefab;
    private Player player1;

    void Awake()
    {
        player1 = ReInput.players.GetPlayer(0);
    }
    // Update is called once per frame
    void Update () {
		if(player1.GetButtonDown("Shoot")) {
			Shoot();
		}
	}

	void Shoot() {
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
