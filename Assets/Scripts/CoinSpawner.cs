using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Thank you to Kier for helping with the pool generation

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

        while (i < 50)
        {
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
        Vector2 velocity = new Vector2 (0,0);
        float x;
        float y;
        

        bool pointOccupied = true;

        while (pointOccupied == true)
        {
            //check if the spawnpoint is clear, if not, reroll
            switch (Caller.tag)
            {
                case "CoinSpawner":

                    x = Random.Range(-4.7f, 4.7f);
                    y = Random.Range(-4.7f, 4.7f);


                    spawnPoint = new Vector3(x, y, 7f);

                    pointOccupied = IsPointOccupied(spawnPoint);

                    break;

                case "Purchased":

                    spawnPoint = Coords;

                    x = Random.Range(-2f, 2f);
                    y = Random.Range(-2f, 2f);
                    velocity = new Vector2(x, y);

                    pointOccupied = false;

                    break;

            }

            //gameObject.activeSelf

        }

        if (pointOccupied == false)
        {
            int i = 0;
            while (Coins[i].activeSelf == true)
            {
                i++;
            }

            Coins[i].SetActive(true);
            Coins[i].transform.position = spawnPoint;
            Coins[i].GetComponent<Rigidbody2D>().velocity = velocity;
        }
    }

    public bool IsPointOccupied(Vector3 point)
    {
        var hitColliders = Physics2D.CircleCast(point, 0.1f, new Vector2(0, 0));
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
