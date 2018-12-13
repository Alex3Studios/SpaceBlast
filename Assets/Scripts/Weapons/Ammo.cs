using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    public int damage;
    public Rigidbody2D rb;
    public float destroytimer;
    public string shooter;

    // Use this for initialization
    void Start()
    {
        //Destroy(gameObject, destroytimer);
        StartCoroutine("DestroyByTime");
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag != "Crate" && gameObject.layer != 14 && hitInfo.tag != "slowmo")
        {
            Debug.Log("Destroyed: " + hitInfo.tag);
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02F;
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyByTime()
    {
        yield return new WaitForSeconds(destroytimer);
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02F;
        Destroy(gameObject);
    }
}
