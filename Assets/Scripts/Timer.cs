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
        int spawnLoc = Random.Range(0, 6);
        int spawnLoc2 = Random.Range(0, 6);
        while (true)
        {
            if (spawnLoc == spawnLoc2)
            {
                spawnLoc2 = Random.Range(0, 6);
            }
            else
                break;
        }
        Vector2 pos = new Vector2(weaponPosX[spawnLoc], weaponPosY[spawnLoc]);
        Vector2 pos2 = new Vector2(weaponPosX[spawnLoc2], weaponPosY[spawnLoc2]);

        GameObject wep = (GameObject)Resources.Load("Prefab/Guns/" + weaponList[Random.Range(0, 2)], typeof(GameObject));
        Instantiate(wep, pos, transform.rotation);
        wep = (GameObject)Resources.Load("Prefab/Guns/" + weaponList[Random.Range(0, 2)], typeof(GameObject));
        Instantiate(wep, pos2, transform.rotation);
    }
}
