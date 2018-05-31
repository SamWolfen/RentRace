﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PullScore : MonoBehaviour {
    public GameObject Player;
    private Text text;
    private ScoreHolder scores;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //move to somehting called less often to save power
        text = GetComponent<Text>();
        scores = Player.GetComponent<ScoreHolder>();

        switch(this.name)
        {
            case "ScoreDisplay":
                text.text = "Total Money: " + scores.Score;
                break;

            case "CashOnHandDisplay":
                text.text = "Wallet: " + scores.Cash;
                break;

            case "CashInBankDisplay":
                text.text = "Bank: " + scores.Bank;
                break;

        }
        
    }
}
