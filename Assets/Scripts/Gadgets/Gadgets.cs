using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gadgets : MonoBehaviour
{
    public GameObject gadget;

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
        if (hitInfo.tag == "PlayerTwo" || hitInfo.tag == "PlayerOne")
        {
            GameObject jetpack;
            if (hitInfo.tag == "PlayerTwo")
            {
                /*var player = hitInfo.GetComponent<PlayerTwo>();
                ammoText = GameObject.FindGameObjectWithTag("PlayerTwoAmmo");
                weaponSlot = player.transform.GetChild(1).gameObject;
                powerupdisplay = GameObject.FindGameObjectWithTag("PlayerTwoPowerUp");
                player.specialAmmo = weaponAmmoCapacity;
                player.maxAmmoCapacity = weaponAmmoCapacity;
				*/
            }

            var player = hitInfo.GetComponent<PlayerOne>();
            jetpack = player.transform.GetChild(4).gameObject;
            GameObject jetpackSprite = Resources.Load<GameObject>("Prefab/Gadgets/Jetpack_off");
            jetpack.GetComponent<SpriteRenderer>().sprite = jetpackSprite.GetComponent<SpriteRenderer>().sprite;
            hitInfo.GetComponent<PlayerOne>().fuel = 1000;
            Destroy(gameObject);
        }
    }
}
