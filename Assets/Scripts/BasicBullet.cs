﻿using UnityEngine;
using System.Collections;

public class BasicBullet : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 350;
    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 1);
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