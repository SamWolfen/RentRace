using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GatherCoins : MonoBehaviour {
    private ScoreHolder scores;
    public GameObject Player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
           //Debug.Log("colissions");

            //scores.CoinGet(scores);            
            //Destroy(gameObject);
        }
    }
}
