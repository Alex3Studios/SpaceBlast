using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    public static int PlayerOneScoreValue = 0;
    public static int PlayerOneHealthValue = 1000;
    public static int PlayerTwoScoreValue = 0;
    public static int PlayerTwoHealthValue = 1000;
    Text PlayerOneScore;
    Text PlayerOneHealth;
    Text PlayerTwoScore;
    Text PlayerTwoHealth;

    // Use this for initialization
    void Start()
    {
        PlayerOneScore = GetComponent<Text>();
        PlayerOneHealth = GetComponent<Text>();
        PlayerTwoScore = GetComponent<Text>();
        PlayerTwoHealth = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "ScorePlayerOne")
            PlayerOneScore.text = "Score: " + PlayerOneScoreValue;
        else if (gameObject.name == "ScorePlayerTwo")
            PlayerTwoScore.text = "Score: " + PlayerTwoScoreValue;
        else if (gameObject.name == "HealthPlayerOne")
            PlayerOneHealth.text = "Health: " + PlayerOneHealthValue;
        else
            PlayerTwoHealth.text = "Health: " + PlayerTwoHealthValue;

    }
}
