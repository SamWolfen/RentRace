using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this script manages resource gathering and resource expenditure.

public class ScoreHolder : MonoBehaviour {
    public float Score = 0;
    public float Cash = 0;
    public float Bank = 0;

    private float generalTimer = 0;
    private float generalCounter = 0;
    private float interestTimer = 0;
    private float progressTimer = 0;
   
    private IEnumerator buildingCoroutine;

    public GameObject ProgressBar;
    public GameObject ProgressBarGreen;
    public GameObject ProgressBarGrey;
    private GameObject CollidedObject;

    public bool Interacting;

    // Use this for initialization

    void Start () {
        Score = 0;
        Cash = 0;
        Bank = 0;

        StartCoroutine(BankInterest());
		
	}
	
	// Update is called once per frame
	void Update () {
        //Score = Cash + Bank;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        progressTimer = 0;
        CollidedObject = GameObject.Find(collision.name);
        bool valid = false;

        switch (collision.tag)
        {
            case "Coin":
                CoinGet(this);
                //Probably not efficient to destroy, but can replace with pool later
                CollidedObject.SetActive(false);
                break;

            case "Bank":
                //deposit money at a rate
                if (Cash > 0)
                {
                    buildingCoroutine = BuildingAction("Bank");
                    valid = true;
                }
                break;

        }

        if (collision.tag != "Coin" && valid == true)
        {
            Interacting = true;
            StartCoroutine(buildingCoroutine);
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Interacting = false;
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
        float progressBar = 0;
        float progressModifier = 200;
        float distanceX = ProgressBarGreen.transform.localPosition.x - ProgressBarGrey.transform.localPosition.x;

        Vector3 initialPosGreen = ProgressBarGreen.transform.localPosition;

        ProgressBar.SetActive(true);
        ProgressBarGreen.transform.localScale = new Vector3(0.1f,ProgressBarGreen.transform.localScale.y);
        

        switch (building)
        {
            case "Bank":
                requiredProgress = Cash;
                break;
        }

        while (actionComplete == false)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            if (Interacting == true)
            {

                //action
                Progress = Progress + Time.deltaTime * progressModifier;
                progressModifier++;
                progressBar = Progress / requiredProgress;
                Debug.Log(progressBar * 100);

                ProgressBarGreen.transform.localScale = new Vector3(progressBar * ProgressBarGrey.transform.localScale.x, ProgressBarGreen.transform.localScale.y);
                ProgressBarGreen.transform.localPosition = new Vector3(initialPosGreen.x - (distanceX * progressBar), ProgressBarGreen.transform.localPosition.y);

                //test if action is complete
                if (Progress >= requiredProgress)
                {
                    //complete action reset loading bar
                    Invest(building);
                    ProgressBar.SetActive(false);
                    ProgressBarGreen.transform.localPosition = initialPosGreen;

                    actionComplete = true;
                };

            }
            else
            {
                ProgressBar.SetActive(false);
                ProgressBarGreen.transform.localPosition = initialPosGreen;
                actionComplete = true;
            }


        }

        yield return null; 
    }

    private IEnumerator BankInterest()
    {
        bool coroutineRun = true;

        while (coroutineRun)
        {
            yield return new WaitForSecondsRealtime(5f);

            Bank = Bank + (Bank * 0.01f);
            Bank =  (float)Math.Round(Bank, 2);


        }
    }
}
