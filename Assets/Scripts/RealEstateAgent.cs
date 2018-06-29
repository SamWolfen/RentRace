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
        StartCoroutine(FixPathing());
        //BuggyPathingFix();
    }

   IEnumerator FixPathing()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime (0.5f);
            GetComponent<Pathfinding.AILerp>().SearchPath();
        }
    }


    void DepositMoney()
    {
        Player.GetComponent<ScoreManagerAndInteraction>().Bank += gatheredCoins;
        Player.GetComponent<ScoreManagerAndInteraction>().AddUpScore();
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
        //BuggyPathingFix();
    }

    private void Update()
    {
        
    }
    public void AgentBubbleToggle(bool trulse)
    {
        SpeechBubble.GetComponent<SpeechToggle>().ToggleCantFindCoin(trulse);
    }

    void BuggyPathingFix()
    {
        GetComponent<Pathfinding.AILerp>().enabled = false;
        GetComponent<Pathfinding.AILerp>().enabled = true;
    }

}
