using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ricochet : MonoBehaviour {

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
		else if(hitInfo.tag == "bullet" || hitInfo.tag == "Basic Bullet")
		{
			Destroy(gameObject);
		}
    }
}
