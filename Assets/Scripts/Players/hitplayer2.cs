using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitplayer2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
    {
        int damage;
		var player = gameObject.GetComponentInParent<PlayerTwo>();
        if(hitInfo.tag == "bullet" || hitInfo.tag == "Basic Bullet")
        {
            Time.timeScale = 1;
 			Time.fixedDeltaTime = 0.02F;
            if(hitInfo.tag == "bullet")
            {
                damage = hitInfo.GetComponent<Ammo>().damage;
                Destroy(hitInfo.gameObject);
				player.TakeDamage(damage);
            }
            else
            {
                damage = hitInfo.GetComponent<BasicBullet>().damage;
                Destroy(hitInfo.gameObject);
                player.TakeDamage(damage);
            }
        }
    }
}
