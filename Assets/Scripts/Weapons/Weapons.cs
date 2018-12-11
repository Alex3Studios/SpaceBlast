using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    public enum Modes
    { Melee, Straight, Follow, Throw, Burst }
    public Sprite sprite;
    public GameObject projectile;

    public GameObject weapon;
    public int ammoCapacity;
    public static int ammo;
    public float projectileSpeed;
    public float cooldown;
    public float recoil;
    public Modes projectileMode;


    // Use this for initialization
    void Start()
    {
        ammo = ammoCapacity;
    }
}
