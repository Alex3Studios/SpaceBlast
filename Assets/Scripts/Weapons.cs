﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {

	public enum Modes
	{ Melee, Straight, Follow, Throw}
	public Sprite sprite;
	public GameObject projectile;
	public float projectileSpeed;
	public float cooldown;
	public Modes projectileMode;


	// Use this for initialization
	void Start () {
		
	}
}
