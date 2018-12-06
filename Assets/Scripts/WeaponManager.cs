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
    public float Shoot()
    {
        if(canshoot && activeWeapon != null)
        {
            canshoot = false;
            StartCoroutine("Cooldown");

            if (wpn.projectileMode == Weapons.Modes.Straight)
            {
                GameObject projectile = (GameObject)Instantiate(wpn.projectile, transform.position + transform.parent.rotation * (activeWeapon.transform.GetChild(0).localPosition), transform.parent.rotation);
                projectile.GetComponent<Rigidbody2D>().velocity = transform.parent.right * wpn.projectileSpeed;
            }
            if(wpn.projectileMode == Weapons.Modes.Burst)
            {
                GameObject projectile = (GameObject)Instantiate(wpn.projectile, transform.position + transform.parent.rotation * (activeWeapon.transform.GetChild(0).localPosition), transform.parent.rotation);
                projectile.GetComponent<Rigidbody2D>().velocity = transform.parent.right * wpn.projectileSpeed;
                GameObject projectile2 = (GameObject)Instantiate(wpn.projectile, transform.position + transform.parent.rotation * (activeWeapon.transform.GetChild(0).localPosition * 2), transform.parent.rotation);
                projectile2.GetComponent<Rigidbody2D>().velocity = transform.parent.right * wpn.projectileSpeed;
                GameObject projectile3 = (GameObject)Instantiate(wpn.projectile, transform.position + transform.parent.rotation * (activeWeapon.transform.GetChild(0).localPosition * 3), transform.parent.rotation);
                projectile3.GetComponent<Rigidbody2D>().velocity = transform.parent.right * wpn.projectileSpeed;

                 return (wpn.recoil * 3);
            }
            return wpn.recoil;
        }
        return 0;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(wpn.cooldown);
        canshoot = true;
    }
}
