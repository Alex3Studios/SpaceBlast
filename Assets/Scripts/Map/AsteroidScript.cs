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

    public float xRight = 50;
    public float xLeft = -32;
    public float yTop = 15;
    public float yBottom = -30;

    /*********************************************
     * Initializes items with this script with a *
     * 2D Vector with a random amount of thrust  *
     * and a random amount of torque within the  *
     * given -max and max values                 *
     ********************************************/
    void Start() {
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);
        rb.AddForce(thrust);
        rb.AddTorque(torque);
    }

    /************************************************
     * Provides screen wrapping, the asteroids that *
     * go outside of the screen vies come back in   *
     * on the opposite side of the screen as well   *
     * ignoring layer collision with items on the   *
     * 'border' layer                               *
     ***********************************************/
    void Update() {
        Physics2D.IgnoreLayerCollision(9, 10);
        Vector2 newPos = transform.position;

        if (transform.position.y > yTop) {
            newPos.y = yBottom;
        }
        else if (transform.position.y < yBottom) {
            newPos.y = yTop;
        }
        else if (transform.position.x > xRight) {
            newPos.x = xLeft;
        }
        else if (transform.position.x < xLeft) {
            newPos.x = xRight;
        }

        transform.position = newPos;
    }

    /**********************************************
     * When triggered with the 'bullet' tag (e.g. * 
     * bullets from power-up guns), then destroys *
     * the asteroid and spawns two asteroids a    *
     * size smaller, unless it's the smalles ones *
     * in which case the asteroid is just         *
     * destroyed. However this does not apply to  *
     * the ricochet which has a special effect    *
     * and therefore this does not apply to objs  *
     * on layer 14. Items with the 'basic bullet' *
     * tag are also allowed to destroy asteroids  *
     * of the smallest size                       *
     *********************************************/
    void OnTriggerEnter2D(Collider2D other) {
        // Check if it's a bullet
        if (other.CompareTag("bullet") && other.gameObject.layer != 14) {
            // Destroy the bullet
            Destroy(other.gameObject);
            // Check the size of the asteroid and spawn in the next smaller size
            if (asteroidSize == 3) {
                Instantiate(asteroidMedium, transform.position, transform.rotation);
                Instantiate(asteroidMedium, transform.position, transform.rotation);
            }
            else if (asteroidSize == 2) {
                Instantiate(asteroidSmall, transform.position, transform.rotation);
                Instantiate(asteroidSmall, transform.position, transform.rotation);
            }
            // Remove the asteroid
            Destroy(gameObject);
        }
        // Also allow basic bullets to destroy the smallest ones
        else if (other.CompareTag("Basic Bullet")) {
            if (asteroidSize == 1) {
                Destroy(gameObject);
            }
        }
    }
}
