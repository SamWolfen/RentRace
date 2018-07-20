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
    public bool isActive;




    // Use this for initialization
    void Start()
    {
        //StartCoroutine(FixPathing());
        //BuggyPathingFix();
        isActive = false;
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
        //GetComponent<Pathfinding.AILerp>().SearchPath();
    }

    private void Update()
    {
        if (isActive)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;



        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<PathFinding>().Target = GetComponent<PathFinding>().FindNearestTarget(GetComponent<PathFinding>().Pather, 1, "HiredAgency");
        }
    }
    public void AgentBubbleToggle(bool trulse)
    {
        SpeechBubble.GetComponent<SpeechToggle>().ToggleCantFindCoin(trulse);
    }



}
