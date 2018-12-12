using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    public int damage;
    public Rigidbody2D rb;
    public float destroytimer;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, destroytimer);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag != "Crate" && gameObject.layer != 14)
        {
            Destroy(gameObject);
        }
    }
}
