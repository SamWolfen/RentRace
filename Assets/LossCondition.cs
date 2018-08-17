using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossCondition : MonoBehaviour
{

    public GameObject Player;
    public GameObject LossText;
    public int hits;
    public int hitLimit;
    public bool lose;

    // Use this for initialization
    void Start()
    {
        lose = false;
        LossText.SetActive(false);
        StartCoroutine(Checker());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Checker()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);

            //check conditions
            if (hits >= hitLimit)
            {
                lose = true;
                hits = hitLimit;
            }


            if (lose == true)
            {
                //trigger win screen and end level
                LossText.SetActive(true);
                GetComponent<WinCondition>().Pause(true);
            }



        }
    }
}
