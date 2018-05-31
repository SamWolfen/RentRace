using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHolder : MonoBehaviour {
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
        //Score = Cash + Bank;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.tag == "Coin")
        {
            CoinGet(this);
            //Probably not efficient to destroy, but can replace with pool later
            DestroyObject(GameObject.Find(collision.name));
        }

    }

    public void CoinGet(ScoreHolder scoreHolder)
    {
        //increases score
        scoreHolder.Cash = scoreHolder.Cash + 10;
        scoreHolder.Score = scoreHolder.Cash + scoreHolder.Bank;
    }
}
