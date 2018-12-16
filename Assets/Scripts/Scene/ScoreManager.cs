using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public Sprite Green;

    public Sprite Yellow;
    
    private Rounds roundmanager;

    private int frame;

    // Use this for initialization
    void Start()
    {
        roundmanager = GameObject.FindGameObjectWithTag("scorekeeper").GetComponent<Rounds>();
        if (roundmanager.round != 0)
        {
            for (int i = 0; i < roundmanager.round; i++)
            {
                if (roundmanager.roundwinner[i] == 0)
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
        if (frame != Time.frameCount)
        {
            frame = Time.frameCount;
            //Debug.Log(looser + " Frame: " + Time.frameCount);
            int temp = 0;
            if (looser == "PlayerTwo")
            {
                temp = roundmanager.Won(0);
            }
            else
            {
                temp = roundmanager.Won(1);
            }


            if (temp != 3)
            {
                Time.timeScale = 1;
                Time.fixedDeltaTime = 0.02F;
                SceneManager.LoadScene("CountDown");
            }
            else
            {
                GameManager gm = FindObjectOfType<GameManager>();
                if (looser == "PlayerTwo")
                {
                    gm.winner = "Yellow";
                }
                else
                {
                    gm.winner = "Green";
                }
                roundmanager.round = 0;
                gm.EndGame();
            }
        }
    }
}
