using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
    {
		Debug.Log(hitInfo);
        PlayerOne playerOne = hitInfo.GetComponent<PlayerOne>();
        PlayerTwo playerTwo = hitInfo.GetComponent<PlayerTwo>();

        if (playerTwo != null || playerOne != null)
        {
            Destroy(gameObject);
        }
    }
}
