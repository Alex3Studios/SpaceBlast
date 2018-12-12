using UnityEngine;
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
        if (hitInfo.tag != "Crate" && hitInfo.tag != "slowmo")
        {
            Time.timeScale = 1;
 			Time.fixedDeltaTime = 0.02F;
            Destroy(gameObject);
        }
    }
}
