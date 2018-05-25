using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHolder : MonoBehaviour {

    public GameObject TotalScore;
    public GameObject CashInHand;
    public GameObject BankDisplay;

    public int Score = 0;
    public int Cash = 0;
    public int Bank = 0;


	// Use this for initialization
	void Start () {
        Score = 0;
        Cash = 0;
        Bank = 0;
        
		
	}
	
	// Update is called once per frame
	void Update () {
        Score = Cash + Bank;

    }

    public void OnColliderEnter2D(Collider2D collision)
    {
        
    }
}
