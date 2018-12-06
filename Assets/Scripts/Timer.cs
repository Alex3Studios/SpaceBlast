using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    string[] weaponList = { "Aliens", "RocketLauncher" };       //Fix later for final handin, this is just a temp fix
    float[] weaponPosX = { 5.5f, -10.06f, 20.48f, 14.47f, 14.47f, -1.02f, -1.02f };
    float[] weaponPosY = { -5.5f, -15.01f, 3.57f, -0.47f, -10.62f, -0.47f, -10.62f };

    public float initialCountdown = 5;
    public int minSpawnTime;
    public int maxSpawnTime;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        initialCountdown -= Time.deltaTime;
        if (initialCountdown <= 0)
        {
            initialCountdown = Random.Range(minSpawnTime, maxSpawnTime);
            SpawnRandomWeapon();
        }
    }

    void SpawnRandomWeapon()
    {
        float x1 = Random.Range(-16.5f, 27.5f);
        float x2 = Random.Range(-16.5f, 27.5f);
        float y1 = Random.Range(-18f, 8.5f);
        float y2 = Random.Range(-18f, 8.5f);
        Vector2 pos = new Vector2(x1, y1);
        while (true)
        {
            if (System.Math.Abs(x1 - x2) < 8)
            {
                x2 = Random.Range(-16.5f, 27.5f);
                continue;
            }
            else if (System.Math.Abs(y1 - y2) < 8)
            {
                y2 = Random.Range(-18f, 8.5f);
                continue;
            }
            else
                break;
        }

        Vector2 pos2 = new Vector2(x2, y2);

        GameObject wep = (GameObject)Resources.Load("Prefab/Guns/" + weaponList[Random.Range(0, 2)], typeof(GameObject));
        Instantiate(wep, pos, transform.rotation);
        wep = (GameObject)Resources.Load("Prefab/Guns/" + weaponList[Random.Range(0, 2)], typeof(GameObject));
        Instantiate(wep, pos2, transform.rotation);
    }
}
