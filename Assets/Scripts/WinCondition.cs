using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject Player;
    public GameObject WinText;
    float score = 0;
    public float scoreGoal;
    public bool win;
    // Use this for initialization
    void Start()
    {
        win = false;
        WinText.SetActive(false);
        StartCoroutine(Checker());
        Time.timeScale = 1;
        
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
                WinText.SetActive(true);
                Pause(true);

            }
            
        }


    }

    public void Pause(bool pause)
    {
        if (pause == true)
        {
            Time.timeScale = 0;

        }
        else
        {
            Time.timeScale = 1;
        }
        
    }

}
