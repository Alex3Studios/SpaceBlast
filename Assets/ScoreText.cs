using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    public static int PlayerOneScoreValue = 0;
    public static int PlayerTwoScoreValue = 0;
    Text PlayerOneScore;
    Text PlayerTwoScore;

    // Use this for initialization
    void Start()
    {
        PlayerOneScore = GetComponent<Text>();
        PlayerTwoScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "ScorePlayerOne")
            PlayerOneScore.text = "Score: " + PlayerOneScoreValue;
        else
            PlayerTwoScore.text = "Score: " + PlayerTwoScoreValue;
    }
}
