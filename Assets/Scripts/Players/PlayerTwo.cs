﻿using UnityEngine;
using System.Collections;
using Rewired;
using UnityEngine.UI;

public class PlayerTwo : MonoBehaviour
{

    public int health = 1000;
    public int specialAmmo;
    public int maxAmmoCapacity;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private Player player2;
    bool scoreCheck;
    public GameObject deathEffect;
    Text PlayerTwoAmmo;
    void Start()
    {
        PlayerTwoAmmo = GetComponent<Text>();
        ScoreText.PlayerTwoHealthValue = health;
        scoreCheck = true;
    }
    void Awake()
    {
        player2 = ReInput.players.GetPlayer(1);
    }

    //Update Function
    void Update()
    {
        GameObject ammoTextPlayerTwo = GameObject.FindGameObjectWithTag("PlayerTwoAmmo");
        float MoveX = player2.GetAxis("RotateX");
        float MoveY = player2.GetAxis("RotateY");
        float heading = Mathf.Atan2(MoveY, MoveX);

        transform.rotation = Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg);
        if (player2.GetButtonDown("Shoot"))
        {
            Shoot();
            Recoil(7);
        }
        if (player2.GetButtonDown("PowerUp"))
        {
            GameObject weaponmanagerObject = transform.GetChild(1).gameObject;
            WeaponManager wm = weaponmanagerObject.GetComponent<WeaponManager>();
            if (specialAmmo > 0)
            {
                float recoil = wm.Shoot();
                Recoil(recoil);
                if (recoil != 0)
                {
                    specialAmmo -= 1;
                    ammoTextPlayerTwo.GetComponent<UnityEngine.UI.Text>().text = specialAmmo + "/" + maxAmmoCapacity;
                }
                if (specialAmmo < 1)
                    RemoveWeapon(ammoTextPlayerTwo, wm);
            }
            else if (wm.activeWeapon != null)
            {
                RemoveWeapon(ammoTextPlayerTwo, wm);
            }

        }
    }

    void RemoveWeapon(GameObject ammoTextPlayerTwo, WeaponManager wm)
    {
        GameObject powerup = GameObject.FindGameObjectWithTag("PlayerTwoPowerUp");
        powerup.GetComponent<SpriteRenderer>().sprite = powerup.GetComponent<powerup>().defaultsprite;
        wm.activeWeapon = null;
        wm.GetComponent<SpriteRenderer>().sprite = null;
        ammoTextPlayerTwo.GetComponent<UnityEngine.UI.Text>().text = "  0" + "/" + "0";
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    public void Recoil(float recoil)
    {

        GetComponent<Rigidbody2D>().AddForce(transform.right * -1 * recoil, ForceMode2D.Impulse);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            ScoreText.PlayerTwoHealthValue = 0;
            Debug.Log("Dead");
            Die();
        }
        else
        {
            ScoreText.PlayerTwoHealthValue = health;
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        if (scoreCheck == true)
        {
            scoreCheck = false;
            Destroy(gameObject);
            ScoreText.PlayerOneScoreValue += 1;
            GameObject powerup = GameObject.FindGameObjectWithTag("PlayerTwoPowerUp");
            powerup.GetComponent<SpriteRenderer>().sprite = powerup.GetComponent<powerup>().defaultsprite;
            GameObject ammoTextPlayerTwo = GameObject.FindGameObjectWithTag("PlayerTwoAmmo");
            ammoTextPlayerTwo.GetComponent<UnityEngine.UI.Text>().text = "  0" + "/" + "0";
        }
    }
}
