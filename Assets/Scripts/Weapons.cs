﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    public enum Modes
    { Melee, Straight, Follow, Throw, Burst}
    public Sprite sprite;
    public GameObject projectile;

    public GameObject weapon;
    public float projectileSpeed;
    public float cooldown;
    public float recoil;
    public Modes projectileMode;


    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerOne playerOne = hitInfo.GetComponent<PlayerOne>();
        PlayerTwo playerTwo = hitInfo.GetComponent<PlayerTwo>();

        if (playerTwo != null)
        {
            GameObject weaponSlot = playerTwo.transform.GetChild(1).gameObject;
            WeaponManager activateWeapon = weaponSlot.GetComponent<WeaponManager>();
            GameObject wep = (GameObject)Resources.Load("Prefab/Guns/" + weapon.name, typeof(GameObject));
            activateWeapon.activeWeapon = wep;
            activateWeapon.initialize();

            Destroy(gameObject);
        }
        if (playerOne != null)
        {
            Debug.Log(weapon.name);
            GameObject weaponSlot = playerOne.transform.GetChild(1).gameObject;
            WeaponManager activateWeapon = weaponSlot.GetComponent<WeaponManager>();
            GameObject wep = (GameObject)Resources.Load("Prefab/Guns/" + weapon.name, typeof(GameObject));
            activateWeapon.activeWeapon = wep;
            activateWeapon.initialize();

            Destroy(gameObject);
        }
    }
}
