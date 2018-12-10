﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour {

    public GameObject WeaponHere;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerOne playerOne = hitInfo.GetComponent<PlayerOne>();
        PlayerTwo playerTwo = hitInfo.GetComponent<PlayerTwo>();

        if (playerTwo != null)
        {
            GameObject weaponSlot = playerTwo.transform.GetChild(1).gameObject;
            WeaponManager activateWeapon = weaponSlot.GetComponent<WeaponManager>();
            activateWeapon.activeWeapon = WeaponHere;
            activateWeapon.initialize();

            Destroy(gameObject);
        }
        if (playerOne != null)
        {
            GameObject weaponSlot = playerOne.transform.GetChild(1).gameObject;
            WeaponManager activateWeapon = weaponSlot.GetComponent<WeaponManager>();
            activateWeapon.activeWeapon = WeaponHere;
            activateWeapon.initialize();

            Destroy(gameObject);
        }
    }
}
