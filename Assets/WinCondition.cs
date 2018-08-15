using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject Player;
    float score = 0;
    public float scoreGoal;
    public bool win;
    // Use this for initialization
    void Start()
    {
        win = false;
        StartCoroutine(Checker());
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Checker()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);

            score = Player.GetComponent<ScoreManagerAndInteraction>().Score;


            if (score >= scoreGoal)
            {
                win = true;
            }

            if (win == true)
            {
                //trigger win screen and end level
            }
            
        }


    }

}
