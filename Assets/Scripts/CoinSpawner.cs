using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CoinSpawner : MonoBehaviour
{
    public GameObject CoinSpawnerObject;
    public GameObject Coin;
    private List<GameObject> Coins = new List<GameObject>(100);


    Vector3 emptyVec = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start()
    {


        int i = 0;

        while (i < 100)
        {
            GameObject newCoin = Instantiate(Coin, transform);
            newCoin.SetActive(false);
            Coins.Add(newCoin);
            
            i++;
        }

        i = 0;

        while (i < 30)
        {
            Coins[i].SetActive(true);
            CoinSpawn(emptyVec, CoinSpawnerObject);
            i++;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CoinSpawn(Vector3 Coords, GameObject Caller)
    {
        Vector3 spawnPoint = emptyVec;
        System.Random rnd = new System.Random();
        bool pointOccupied = true;

        while (pointOccupied != false)
        {
            //check if the spawnpoint is clear, if not, reroll
            switch (Caller.tag)
            {
                case "CoinSpawner":

                    float x = rnd.Next(1, 1);
                    float y = rnd.Next(1, 1);
                    

                    spawnPoint = new Vector3(x, y, 7f);

                    break;

                case "Purchased":

                    spawnPoint = Coords;

                    break;

            }

            pointOccupied = IsPointOccupied(spawnPoint);

            //gameObject.activeSelf

        }

        if (pointOccupied == false)
        {
            int i = 0;
            while (Coins[i].activeSelf == true)
            {
                i++;
            }

            Coins[i].transform.position = spawnPoint;


        }




    }

    public bool IsPointOccupied(Vector3 point)
    {
        var hitColliders = Physics2D.CircleCast(point, 2, new Vector2(0, 0));
        if (hitColliders.collider)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
