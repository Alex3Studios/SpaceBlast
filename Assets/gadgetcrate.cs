using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gadgetcrate : MonoBehaviour {

	public GameObject GadgetHere;
    public GameObject soundPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
    {
        /*if(hitInfo.tag == "PlayerTwo" || hitInfo.tag == "PlayerOne")
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
        }*/

		if (hitInfo.tag == "PlayerTwo" || hitInfo.tag == "PlayerOne")
        {
			var gadgetsprite = transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
			var fuel = GadgetHere.GetComponent<Gadgets>().fuel;
            if (hitInfo.tag == "PlayerTwo")
            {
                var player = hitInfo.GetComponent<PlayerTwo>();
				player.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = GadgetHere.GetComponent<SpriteRenderer>().sprite;
				hitInfo.GetComponent<PlayerTwo>().fuel = GadgetHere.GetComponent<Gadgets>().fuel;
				GameObject.FindGameObjectWithTag("PlayerTwoGadget").GetComponent<SpriteRenderer>().sprite = gadgetsprite;
				var fuelText = GameObject.FindGameObjectWithTag("PlayerTwoFuel");
				fuelText.GetComponent<UnityEngine.UI.Text>().text = fuel + "/" +  fuel;
            }
			else
			{
				var player = hitInfo.GetComponent<PlayerOne>();
				player.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = GadgetHere.GetComponent<SpriteRenderer>().sprite;
				hitInfo.GetComponent<PlayerOne>().fuel = GadgetHere.GetComponent<Gadgets>().fuel;
				GameObject.FindGameObjectWithTag("PlayerOneGadget").GetComponent<SpriteRenderer>().sprite = gadgetsprite;
				var fuelText = GameObject.FindGameObjectWithTag("PlayerOneFuel");
				fuelText.GetComponent<UnityEngine.UI.Text>().text = fuel + "/" +  fuel;
			}
			Destroy(gameObject);
        }
    }
}
