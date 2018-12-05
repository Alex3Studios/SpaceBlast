using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public GameObject activeWeapon;
    Weapons wpn;
    bool canshoot = true;


    // Use this for initialization
    public void initialize()
    {
        wpn = activeWeapon.GetComponent<Weapons>();
        GetComponent<SpriteRenderer>().sprite = wpn.sprite;
    }
    public int Shoot()
    {
        if(canshoot)
        {
            canshoot = false;
            StartCoroutine("Cooldown");

            GameObject projectile = (GameObject)Instantiate(wpn.projectile, transform.position + transform.parent.rotation * (activeWeapon.transform.GetChild(0).localPosition), transform.parent.rotation);
            Debug.Log(activeWeapon.transform.GetChild(0).gameObject.name);
            if (wpn.projectileMode == Weapons.Modes.Straight)
            {
                projectile.GetComponent<Rigidbody2D>().velocity = transform.parent.right * wpn.projectileSpeed;
            }
        }
        return 0;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(wpn.cooldown);
        canshoot = true;
    }
}
