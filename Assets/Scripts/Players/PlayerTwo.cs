﻿using UnityEngine;
using System.Collections;
using Rewired;
using UnityEngine.UI;

public class PlayerTwo : MonoBehaviour
{

    public int health = 1000;
    public int specialAmmo;
    public int maxAmmoCapacity;
    public int fuel;
    public int fuelCapacity;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private Player player2;
    public Sprite jetpackOn;
    public Sprite jetpackOff;
    public GameObject healthBar;
    void Start()
    {
        Sprite healthBarSprite = Resources.Load<Sprite>("Health/Health bar15");
        healthBar.GetComponent<SpriteRenderer>().sprite = healthBarSprite;
    }
    void Awake()
    {
        player2 = ReInput.players.GetPlayer(1);
    }

    //Update Function
    void Update()
    {
        if (Time.timeScale != 0)
        {
            GameObject ammoTextPlayerTwo = GameObject.FindGameObjectWithTag("PlayerTwoAmmo");
            GameObject fuelTextPlayerTwo = GameObject.FindGameObjectWithTag("PlayerTwoFuel");
            Sprite jetpackSlot = gameObject.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite;
            float MoveX = player2.GetAxis("RotateX");
            float MoveY = player2.GetAxis("RotateY");
            float heading = Mathf.Atan2(MoveY, MoveX);
            if (heading != 0)
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
                    float recoil = wm.Shoot(gameObject.tag);
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
            if (jetpackSlot && player2.GetButton("gadget"))
            {
                GetComponent<Rigidbody2D>().AddForce(transform.up * 75);
                fuel -= 1;
                gameObject.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite = jetpackOn;
                fuelTextPlayerTwo.GetComponent<UnityEngine.UI.Text>().text = fuel + "/" + fuelCapacity;
                if (fuel < 1)
                {
                    RemoveGadget(fuelTextPlayerTwo);
                }
            }
            else if (jetpackSlot)
            {
                gameObject.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite = jetpackOff;
            }
        }
    }

    void RemoveWeapon(GameObject ammoTextPlayerTwo, WeaponManager wm)
    {
        GameObject powerup = GameObject.FindGameObjectWithTag("PlayerTwoPowerUp");
        powerup.GetComponent<SpriteRenderer>().sprite = powerup.GetComponent<PowerUp>().defaultsprite;
        wm.activeWeapon = null;
        wm.GetComponent<SpriteRenderer>().sprite = null;
        ammoTextPlayerTwo.GetComponent<UnityEngine.UI.Text>().text = "  0" + "/" + "0";
    }

    void RemoveGadget(GameObject fuelTextPlayerTwo)
    {
        GameObject gadget = GameObject.FindGameObjectWithTag("PlayerTwoGadget");
        gadget.GetComponent<SpriteRenderer>().sprite = GameObject.FindGameObjectWithTag("PlayerTwoPowerUp").GetComponent<PowerUp>().defaultsprite;
        gameObject.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().sprite = null;
        fuelTextPlayerTwo.GetComponent<UnityEngine.UI.Text>().text = "  0" + "/" + "0";
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
            Die();
        }
        else
        {
            float tempHealth = health;
            int count = 0;
            while (tempHealth > 1)
            {
                tempHealth -= 71.36f;
                count++;
            }
            Sprite healthBarSprite = Resources.Load<Sprite>("Health/Health bar" + count);
            healthBar.GetComponent<SpriteRenderer>().sprite = healthBarSprite;
        }
    }

    void Die()
    {
        ScoreManager round = GameObject.FindGameObjectWithTag("Rounds").GetComponent<ScoreManager>();
        round.Winner(gameObject.tag);
        Destroy(gameObject);
        Sprite healthBarSprite = Resources.Load<Sprite>("Health/Health bar0");
        healthBar.GetComponent<SpriteRenderer>().sprite = healthBarSprite;
    }
}
