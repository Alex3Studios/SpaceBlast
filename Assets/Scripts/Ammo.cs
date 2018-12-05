using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    public int damage;
    public Rigidbody2D rb;
    public int destroytimer;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, destroytimer);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerOne playerOne = hitInfo.GetComponent<PlayerOne>();
        PlayerTwo playerTwo = hitInfo.GetComponent<PlayerTwo>();

        if (playerTwo != null)
        {
            playerTwo.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (playerOne != null)
        {
            playerOne.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (playerOne == null && playerTwo == null)
        {
            Destroy(gameObject);
        }
    }
}
