using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GatherCoins : MonoBehaviour {

    

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("colissions");

        if (collision.name == "Player")
        {


            Destroy(gameObject);
        }
    }
}
