using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public GameObject[] weaponList;
    public GameObject crate;

    public GameObject gadgetcrate;
    float x1, x2, y1, y2;

    public float initialCountdownGun = 5;
    public int minSpawnTimeGun;
    public int maxSpawnTimeGun;

    public float initialCountdownGadget = 8;
    public int minSpawnTimeGadget;
    public int maxSpawnTimeGadget;


    // Update is called once per frame
    void Update()
    {
        initialCountdownGun -= Time.deltaTime;
        initialCountdownGadget -= Time.deltaTime;
        if (initialCountdownGun <= 0)
        {
            initialCountdownGun = Random.Range(minSpawnTimeGun, maxSpawnTimeGun);
            SpawnRandomWeapon();
        }
        if (initialCountdownGadget <= 0)
        {
            initialCountdownGadget = Random.Range(minSpawnTimeGadget, maxSpawnTimeGadget);
            SpawnRandomGadget();
        }

    }
    void GenerateRandomPosition()
    {
        x1 = Random.Range(-16.5f, 27.5f);
        x2 = Random.Range(-16.5f, 27.5f);
        y1 = Random.Range(-20f, 8f);
        y2 = Random.Range(-20f, 8f);
        if (System.Math.Abs(x1 - x2) < 8 || System.Math.Abs(y1 - y2) < 8)
            GenerateRandomPosition();
    }

    void SpawnRandomWeapon()
    {
        GenerateRandomPosition();
        Vector2 pos = new Vector2(x1, y1);
        Vector2 pos2 = new Vector2(x2, y2);

        GameObject wep = weaponList[Random.Range(0, weaponList.Length)];
        Crate lootcrate = crate.GetComponent<Crate>();
        lootcrate.WeaponHere = wep;
        crate.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = wep.GetComponent<SpriteRenderer>().sprite;
        Instantiate(crate, pos, transform.rotation);
        wep = weaponList[Random.Range(0, weaponList.Length)];
        lootcrate = crate.GetComponent<Crate>();
        lootcrate.WeaponHere = wep;
        crate.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = wep.GetComponent<SpriteRenderer>().sprite;
        Instantiate(crate, pos2, transform.rotation);
    }

    void SpawnRandomGadget()
    {
        Vector2 pos = new Vector2(5.65f, -7.28f);

        Instantiate(gadgetcrate, pos, transform.rotation);
    }
}
