using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GatherCoins : MonoBehaviour {
    private ScoreHolder scores;
    public GameObject Player;

    void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("colissions");

        if (collision.name == "Player")
        {
            scores = Player.GetComponent<ScoreHolder>();
            scores.Cash = scores.Cash + 10;
            
            Destroy(gameObject);
        }
    }
}
