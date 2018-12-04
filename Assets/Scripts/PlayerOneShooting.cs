using UnityEngine;
using System.Collections;

public class PlayerOneShooting : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletPrefab;
	
	// Update is called once per frame
	void Update () {
		PlayerOneController pm = GetComponent<PlayerOneController>();
		if(Input.GetButtonDown("Fire1")) {
			Shoot();
			pm.Recoil();
		}
	}

	void Shoot() {
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
