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
        if(hitInfo.tag == "PlayerTwo" || hitInfo.tag == "PlayerOne")
        {
            GameObject ammoText;
            GameObject weaponSlot;
            GameObject powerupdisplay;
            var weaponAmmoCapacity = WeaponHere.GetComponent<Weapons>().ammoCapacity;
            if (hitInfo.tag == "PlayerTwo")
            {
                var player = hitInfo.GetComponent<PlayerTwo>();
                ammoText = GameObject.FindGameObjectWithTag("PlayerTwoAmmo");
                weaponSlot = player.transform.GetChild(1).gameObject;
                powerupdisplay = GameObject.FindGameObjectWithTag("PlayerTwoPowerUp");
                player.specialAmmo = weaponAmmoCapacity;
                player.maxAmmoCapacity = weaponAmmoCapacity;
            }
            else
            {
                var player = hitInfo.GetComponent<PlayerOne>();
                ammoText = GameObject.FindGameObjectWithTag("PlayerOneAmmo");
                weaponSlot = player.transform.GetChild(1).gameObject;
                powerupdisplay = GameObject.FindGameObjectWithTag("PlayerOnePowerUp");
                player.specialAmmo = weaponAmmoCapacity;
                player.maxAmmoCapacity = weaponAmmoCapacity;
            }
                powerupdisplay.GetComponent<SpriteRenderer>().sprite = WeaponHere.GetComponent<SpriteRenderer>().sprite;
                WeaponManager activateWeapon = weaponSlot.GetComponent<WeaponManager>();
                activateWeapon.activeWeapon = WeaponHere;
                ammoText.GetComponent<UnityEngine.UI.Text>().text = weaponAmmoCapacity + "/" + weaponAmmoCapacity;
                activateWeapon.initialize();
                Instantiate(soundPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
        }
    }
}
