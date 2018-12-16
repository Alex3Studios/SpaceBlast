using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowmoPlayer2 : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "bullet")
        {
            string shooter = hitInfo.GetComponent<Ammo>().shooter;
            if (shooter != "PlayerTwo" && hitInfo.gameObject.layer != 16)
            {
                Time.timeScale = 0.3f;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
            }
        }
    }
    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "bullet")
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02F;
        }
    }
}
