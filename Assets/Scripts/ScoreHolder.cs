using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHolder : MonoBehaviour {
    public int Score = 0;
    public int Cash = 0;
    public int Bank = 0;
    private float generalTimer = 0;
    private float generalCounter = 0;
    private float interestTimer = 0;
    private float progressTimer = 0;
    private string enteredBuilding = null;
    private IEnumerator coroutine;


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
        progressTimer = 0;
        
        switch (collision.tag)
        {
            case "Coin":
                CoinGet(this);
                //Probably not efficient to destroy, but can replace with pool later
                DestroyObject(GameObject.Find(collision.name));
                break;

            case "Bank":
                //deposit money at a rate
                coroutine = BuildingAction("Bank");
                
                break;

        }

        if (collision.tag != "Coin")
        {
            StartCoroutine(coroutine);
        }

    }

    
    public void CoinGet(ScoreHolder scoreHolder)
    {
        //increases score
        scoreHolder.Cash = scoreHolder.Cash + 10;
        scoreHolder.Score = scoreHolder.Cash + scoreHolder.Bank;
    }

    private void Invest(string BuildingType)
    {
        switch (BuildingType)
        {
            case "Bank":
                Bank += Cash;
                Cash = 0;
                Score = Cash + Bank;
            break;
        }
    }

    private IEnumerator BuildingAction(string building)
    {
        bool actionComplete = false;
        float Progress = 0;
        float requiredProgress = 0;

        switch (building)
        {
            case "Bank":
                requiredProgress = Cash;
                break;
              
        }

        while (actionComplete == false)
        {


            //action
            Progress = Progress + Time.deltaTime * 10;
            Debug.Log(Progress);
            //test if action is complete
            if (Progress >= requiredProgress)
            {
                Invest(building);
                actionComplete = true;
            };




        }

        return null; 
    }
}
