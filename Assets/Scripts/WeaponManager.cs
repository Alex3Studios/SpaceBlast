using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public GameObject activeWeapon;
    Weapons wpn;


    // Use this for initialization
    public void initialize()
    {
        wpn = activeWeapon.GetComponent<Weapons>();
        GetComponent<SpriteRenderer>().sprite = wpn.sprite;
    }
    public int Shoot()
    {
        Vector3 rotation = transform.parent.localScale.x == 1 ? Vector3.zero : Vector3.forward * 180;
        GameObject projectile = (GameObject)Instantiate(wpn.projectile, transform.position + activeWeapon.transform.GetChild(0).localPosition, Quaternion.Euler(rotation));

        if (wpn.projectileMode == Weapons.Modes.Straight)
        {
            projectile.GetComponent<Rigidbody2D>().velocity = transform.parent.localScale.x * Vector2.right * wpn.projectileSpeed;
        }
        return 0;
    }
}
