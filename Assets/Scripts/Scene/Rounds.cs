﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rounds : MonoBehaviour
{

    public int round = 0;

    public int[] roundwinner = new int[5];

    private int yellowwins = 0;

    private int greenwins = 0;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    public int Won(int winner)
    {
        if (round == 0)
        {
            yellowwins = 0;
            greenwins = 0;
        }
        roundwinner[round] = winner;
        round++;
        if (winner == 0)
        {
            yellowwins++;
            return yellowwins;
        }
        else
        {
            greenwins++;
            return greenwins;
        }
    }
}
