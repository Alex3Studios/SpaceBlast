﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public GameObject[] weaponList;
    public GameObject crate;
    float x1, x2, y1, y2;
    public float respawnTimePlayer;
    float playerRespawnTimer;

    public float initialCountdownGun = 5;
    public int minSpawnTimeGun;
    public int maxSpawnTimeGun;


    // Use this for initialization
    void Start()
    {
        playerRespawnTimer = respawnTimePlayer;
    }

    // Update is called once per frame
    void Update()
    {
        initialCountdownGun -= Time.deltaTime;
        if (initialCountdownGun <= 0)
        {
            initialCountdownGun = Random.Range(minSpawnTimeGun, maxSpawnTimeGun);
            SpawnRandomWeapon();
        }

        if (GameObject.Find("PlayerOne") == null && GameObject.Find("PlayerOne(Clone)") == null)
        {
            playerRespawnTimer -= Time.deltaTime;
            if (playerRespawnTimer <= 0)
                SpawnPlayer("One");
        }
        else if (GameObject.Find("PlayerTwo") == null && GameObject.Find("PlayerTwo(Clone)") == null)
        {
            respawnTimePlayer -= Time.deltaTime;
            if (respawnTimePlayer <= 0)
                SpawnPlayer("Two");
        }

    }
    void GenerateRandomPosition()
    {
        x1 = Random.Range(-16.5f, 27.5f);
        x2 = Random.Range(-16.5f, 27.5f);
        y1 = Random.Range(-18f, 8.5f);
        y2 = Random.Range(-18f, 8.5f);
        if (System.Math.Abs(x1 - x2) < 8 || System.Math.Abs(y1 - y2) < 8)
            GenerateRandomPosition();
    }

    void SpawnRandomWeapon()
    {
        GenerateRandomPosition();
        Vector2 pos = new Vector2(x1, y1);
        Vector2 pos2 = new Vector2(x2, y2);

        GameObject wep = weaponList[Random.Range(0, weaponList.Length)];
        /*Instantiate(crate, pos, transform.rotation);
        Instantiate(wep, pos, transform.rotation);
        wep = weaponList[Random.Range(0, weaponList.Length)];
        Instantiate(crate, pos2, transform.rotation);
        Instantiate(wep, pos2, transform.rotation);*/
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



    void SpawnPlayer(string playerNumber)
    {
        GenerateRandomPosition();
        float playerOneX;
        float playerOneY;
        float playerTwoX;
        float playerTwoY;
        if (playerNumber == "Two")
        {
            var playerOne = GameObject.FindGameObjectWithTag("PlayerOne");
            if(playerOne == null)
            {
                GenerateRandomPosition();
            }
            else
            {
                playerOneX = playerOne.transform.position.x;
                playerOneY = playerOne.transform.position.y;
                while (true)
                {
                    if (System.Math.Abs(x1 - playerOneX) < 10 || System.Math.Abs(y1 - playerOneY) < 10)
                        GenerateRandomPosition();
                    else
                        break;
                }
            }
        }
        else
        {
            var playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo");
            if(playerTwo == null)
            {
                GenerateRandomPosition();
            }
            else
            {
                playerTwoX = playerTwo.transform.position.x;
                playerTwoY = playerTwo.transform.position.y;
                while (true)
                {
                    if (System.Math.Abs(x1 - playerTwoX) < 10 || System.Math.Abs(y1 - playerTwoY) < 10)
                        GenerateRandomPosition();
                    else
                        break;
                }
            }
        }

        Vector2 pos = new Vector2(x1, y1);
        GameObject playerRespawn = (GameObject)Resources.Load("Prefab/Players/Player" + playerNumber, typeof(GameObject));
        Instantiate(playerRespawn, pos, transform.rotation);
        respawnTimePlayer = playerRespawnTimer;
    }
}