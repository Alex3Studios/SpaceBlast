using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private GameObject explosion;

    // Use this for initialization
    void Start()
    {
        explosion = (GameObject)Resources.Load("Prefab/Ammo/Explosion", typeof(GameObject));
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag != "Crate")
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
