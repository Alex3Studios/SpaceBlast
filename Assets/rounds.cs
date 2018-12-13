using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rounds : MonoBehaviour {

	public int round = 0;

	public int[] roundwinner = new int[5]; 

	private int yellowwins = 0;

	private int greenwins = 0;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int Won(int winner)
	{
		roundwinner[round] = winner;
		round++;
		if(winner == 0)
		{
			yellowwins++;
			return yellowwins;
		}
		else {
			greenwins++;
			return greenwins;
		}
	}
}
