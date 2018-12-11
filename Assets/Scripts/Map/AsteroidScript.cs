using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{

    public float maxThrust;
    public float maxTorque;
    public Rigidbody2D rb;
    public int asteroidSize;    // 3 = Large, 2 = Medium, 1 = Small
    public GameObject asteroidMedium;
    public GameObject asteroidSmall;

    float xRight = 50;
    float xLeft = -32;
    float yTop = 15;
    float yBottom = -30;

    //float outsideScreenRadius = 4;

    // Use this for initialization
    void Start()
    {
        //Add a random amount of torque and thrust to the asteroid
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);
        rb.AddForce(thrust);
        rb.AddTorque(torque);
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(9, 10);

        // Screen wrapping asteroids -> if they go out of screen they come back in on opposite side
        Vector2 newPos = transform.position;

        if (transform.position.y > yTop)
        {
            newPos.y = yBottom;
        }
        else if (transform.position.y < yBottom)
        {
            newPos.y = yTop;
        }
        else if (transform.position.x > xRight)
        {
            newPos.x = xLeft;
        }
        else if (transform.position.x < xLeft)
        {
            newPos.x = xRight;
        }

        transform.position = newPos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if it's a bullet
        if (other.CompareTag("bullet"))
        {
            // Destroy the bullet
            Destroy(other.gameObject);
            // Check the size of the asteroid and spawn in the next smaller size
            if (asteroidSize == 3)
            {
                // Spawn two medium asteroids
                Instantiate(asteroidMedium, transform.position, transform.rotation);
                Instantiate(asteroidMedium, transform.position, transform.rotation);
            }
            else if (asteroidSize == 2)
            {
                // Spawn two small asteroids
                Instantiate(asteroidSmall, transform.position, transform.rotation);
                Instantiate(asteroidSmall, transform.position, transform.rotation);
            }
            // Remove the asteroid
            Destroy(gameObject);
        }
        else if (other.CompareTag("Basic Bullet"))
        {
            if (asteroidSize == 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
