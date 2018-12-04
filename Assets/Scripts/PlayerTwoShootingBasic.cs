using UnityEngine;
using System.Collections;
using Rewired;

public class PlayerTwoShootingBasic : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    private Player player2;

    void Awake()
    {
        player2 = ReInput.players.GetPlayer(1);
    }
    // Update is called once per frame
    void Update()
    {
        if (player2.GetButtonDown("Shoot"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
