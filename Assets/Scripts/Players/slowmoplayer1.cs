﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowmoplayer1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "bullet")
        {
			string shooter = hitInfo.GetComponent<Ammo>().shooter;
			if(shooter != "PlayerOne" &&  hitInfo.gameObject.layer != 16)
			{
				Debug.Log("Enter: " + hitInfo.tag);
				Time.timeScale = 0.3f;
    			Time.fixedDeltaTime = 0.02F * Time.timeScale;
			}
        }
    }
	void OnTriggerExit2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "bullet")
        {
			Debug.Log("Exit: " + hitInfo.tag);
			Time.timeScale = 1;
 			Time.fixedDeltaTime = 0.02F;
        }
    }
}
