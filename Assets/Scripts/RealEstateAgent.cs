using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealEstateAgent : MonoBehaviour
{
    public int gatheredCoins;
    public float maxRuns;
    public GameObject SpeechBubble;
    //public bool isActive;
    public int maxCoins;
    public GameObject Player;
    public GameObject ParentAgency;





    // Use this for initialization
    void Start()
    {
        
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

    //IEnumerator DepositMoney()
    //{


    //    while(gatheredCoins >=10)
    //    {
    //        yield return new WaitForSecondsRealtime(0.5f);
    //        maxCoins -= 10;
    //        gatheredCoins -= 10;
    //        

    //    }
    //    maxCoins = maxCoinHolder;
    //    Runs++;

    //    if (Runs == maxRuns)
    //    {
    //        Runs = 0;
    //        ParentAgency.GetComponent<AgentManager>().AgentFinished();
    //    }


    //    yield break;
    //}

    void DepositMoney()
    {
        Player.GetComponent<ScoreHolder>().Bank += gatheredCoins;
        Player.GetComponent<ScoreHolder>().AddUpScore();
        ParentAgency.GetComponent<AgentManager>().runs++;
        gatheredCoins = 0;

        Debug.Log("deposited");

        ParentAgency.GetComponent<AgentManager>().AgentFinished();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin" && gatheredCoins < maxCoins)
        {
            collision.gameObject.SetActive(false);
            gatheredCoins += 10;
        }

        if (collision.tag == "HiredAgency" && gatheredCoins >= maxCoins)
        {
            DepositMoney();

        }
    }

    public void AgentBubbleToggle(bool trulse)
    {
        SpeechBubble.GetComponent<SpeechToggle>().ToggleCantFindCoin(trulse);
    }


}
