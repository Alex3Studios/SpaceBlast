using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

	public Sprite Green;

	public Sprite Yellow;

	private rounds roundmanager;

	// Use this for initialization
	void Start () {
		roundmanager = GameObject.FindGameObjectWithTag("scorekeeper").GetComponent<rounds>();
		if(roundmanager.round != 0)
		{
			for(int i = 0; i < roundmanager.round; i++)
			{
				if(roundmanager.roundwinner[i] == 0)
				{
					transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = Yellow;
				}
				else
				{
					transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = Green;
				}
			}
		}
	}

	public void Winner(string looser)
	{
		int temp = 0;
		if(looser == "PlayerTwo")
		{
			temp = roundmanager.Won(0);
		}
		else
		{
			temp = roundmanager.Won(1);
		}


		if(temp != 3)
		{
			SceneManager.LoadScene("Main");
		}
		else
		{
			roundmanager.round = 0;
			GameManager gm = FindObjectOfType<GameManager>();
			if(looser == "PlayerTwo")
			{
				gm.winner = "Yellow";
			}
			else
			{
				gm.winner = "Green";
			}
			gm.EndGame();
		}
	}
}
