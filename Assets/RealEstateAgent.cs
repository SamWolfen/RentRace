using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealEstateAgent : MonoBehaviour {
    public int GatheredCoins;
    public float Timer;
    public bool isActive;
    public int MaxCoins;
    public GameObject Player;
    int MaxCoinHolder;
  



	// Use this for initialization
	void Start () {
        MaxCoinHolder = MaxCoins;
	}

    //IEnumerator ReaEstateAgentActing()
    //  {
    //     // bool loop = true;
    //     // while (loop)
    //     // {
    //     //     yield return new WaitForSecondsRealtime(0.3f);
    //     //     if (isActive = true)
    //     //     {

    //     //     }
    //     // }



    //     yield return ;
    //  }

    IEnumerator DepositMoney()
    {
        

        while(GatheredCoins >=10)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            MaxCoins -= 10;
            GatheredCoins -= 10;
            Player.GetComponent<ScoreHolder>().Bank += 10;
            Player.GetComponent<ScoreHolder>().AddUpScore();

            Debug.Log("deposited");

        }
        MaxCoins = MaxCoinHolder;

        yield break;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.tag == "Coin" && GatheredCoins < MaxCoins)
        {
            collision.gameObject.SetActive(false);
            GatheredCoins += 10;
        }

        if (collision.tag == "Agency")
        {
            StartCoroutine(DepositMoney());
            
        }
    }

    
}
