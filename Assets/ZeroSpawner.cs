using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZeroSpawner : MonoBehaviour {

    public GameObject ZeroOne;
    public GameObject ZeroTwo;
    public GameObject ZeroThree;
    public int spawnCounter;
    float x;
    float y;
    Vector2 spawnPoint;
    public bool allZerosCollected;
    public int zerosCollected;


	// Use this for initialization
	void Start () {
        spawnCounter = 0;
        ZeroOne.SetActive(false);
        ZeroTwo.SetActive(false);
        ZeroThree.SetActive(false);
        zerosCollected = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if (zerosCollected == 3)
        {
            allZerosCollected = true;
        }
	}

    public void SpawnZero()
    {
       x = Random.Range(-4.7f, 4.7f);
       y = Random.Range(-4.7f, 4.7f);
       spawnPoint = new Vector2(x, y);

        while (IsPointOccupied(spawnPoint))
        {
            x = Random.Range(-4.7f, 4.7f);
            y = Random.Range(-4.7f, 4.7f);
            spawnPoint = new Vector2(x, y);
        }

        if (!IsPointOccupied(spawnPoint))
        {
            switch (spawnCounter)
            {
                case 1:
                    ZeroOne.SetActive(true);
                    ZeroOne.transform.position = spawnPoint;
                    break;
                case 2:
                    ZeroTwo.SetActive(true);
                    ZeroTwo.transform.position = spawnPoint;
                    break;
                case 3:
                    ZeroThree.SetActive(true);
                    ZeroThree.transform.position = spawnPoint;
                    break;

            }

        }
    }

    bool IsPointOccupied(Vector3 point)
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

