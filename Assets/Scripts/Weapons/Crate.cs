using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{

    public GameObject WeaponHere;
    public GameObject soundPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerOne playerOne = hitInfo.GetComponent<PlayerOne>();
        PlayerTwo playerTwo = hitInfo.GetComponent<PlayerTwo>();

        if (playerTwo != null)
        {
            GameObject ammoTextPlayerTwo = GameObject.FindGameObjectWithTag("PlayerTwoAmmo");
            GameObject weaponSlot = playerTwo.transform.GetChild(1).gameObject;
            GameObject powerupdisplay = GameObject.FindGameObjectWithTag("PlayerTwoPowerUp");
            powerupdisplay.GetComponent<SpriteRenderer>().sprite = WeaponHere.GetComponent<SpriteRenderer>().sprite;
            WeaponManager activateWeapon = weaponSlot.GetComponent<WeaponManager>();
            activateWeapon.activeWeapon = WeaponHere;
            var weaponAmmoCapacity = WeaponHere.GetComponent<Weapons>().ammoCapacity; ;
            playerTwo.specialAmmo = weaponAmmoCapacity;
            playerTwo.maxAmmoCapacity = weaponAmmoCapacity;
            ammoTextPlayerTwo.GetComponent<UnityEngine.UI.Text>().text = playerTwo.specialAmmo + "/" + weaponAmmoCapacity;
            activateWeapon.initialize();
            Instantiate(soundPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (playerOne != null)
        {
            GameObject ammoTextPlayerOne = GameObject.FindGameObjectWithTag("PlayerOneAmmo");
            GameObject weaponSlot = playerOne.transform.GetChild(1).gameObject;
            GameObject powerupdisplay = GameObject.FindGameObjectWithTag("PlayerOnePowerUp");
            powerupdisplay.GetComponent<SpriteRenderer>().sprite = WeaponHere.GetComponent<SpriteRenderer>().sprite;
            WeaponManager activateWeapon = weaponSlot.GetComponent<WeaponManager>();
            activateWeapon.activeWeapon = WeaponHere;
            var weaponAmmoCapacity = WeaponHere.GetComponent<Weapons>().ammoCapacity; ;
            playerOne.specialAmmo = weaponAmmoCapacity;
            playerOne.maxAmmoCapacity = weaponAmmoCapacity;
            ammoTextPlayerOne.GetComponent<UnityEngine.UI.Text>().text = playerOne.specialAmmo + "/" + weaponAmmoCapacity;
            activateWeapon.initialize();
            Instantiate(soundPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
