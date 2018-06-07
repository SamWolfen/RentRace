using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealEstateAgent : MonoBehaviour {
    public int GatheredCoins;
    public float Timer;
    public bool isActive;



	// Use this for initialization
	void Start () {
		
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Coin")
        {

        }
    }
}
