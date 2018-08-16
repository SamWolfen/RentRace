using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuggerSpawner : MonoBehaviour
{

    int spawnCounter = 0;
    public float zeroTimer;
    public GameObject Mugger;
    public GameObject TripleZero;
    public GameObject Police;
    float runTimer;
    public float timer;
    float spawnTimer;
    float rand;
    public bool toggleMugger;

    public enum DiffLevel
    {
        Easy, Medium, Hard
    }

    public DiffLevel difficulty;

    // Use this for initialization
    void Start()
    {
        Mugger.GetComponent<Mugger>().isActive = false;


        ResetValues();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //adjust mugger state based on timer
        //rand = Random.Range(0f, 10f);
        MuggerLogic();




    }

    void MuggerLogic()
    {

        if (toggleMugger)
        {
            //purely for testing
            toggleMugger = false;
            timer = 100;
        }

        if (Mugger.GetComponent<Mugger>().isActive)
        {
            //FOR DIFFERENT SPAWN BEHAVIOR AT DIFFERENT LEVELS!!! 
            switch (difficulty)
            {
                case DiffLevel.Easy:

                    break;

                case DiffLevel.Medium:
                    TripleZeroSpawn();

                    break;
            }


            if (timer >= spawnCounter * 10 + 15)
            {
                // Mugger.GetComponent<Mugger>().isActive = false;
                //ResetValues();

            }
            else
            {
                timer += Time.deltaTime * 1.0f;
            }
        }
        else
        {
            if (timer >= rand + 10)
            {
                Mugger.GetComponent<Mugger>().isActive = true;
                ResetValues();
                spawnCounter++;
            }
            else
            {
                timer += Time.deltaTime * 1.0f;
            }
        }
    }

    void TripleZeroSpawn()
    {
        if (zeroTimer < timer)
        {
            zeroTimer += 2;
            TripleZero.GetComponent<ZeroSpawner>().spawnCounter++;
            TripleZero.GetComponent<ZeroSpawner>().SpawnZero();

        }
    }

    void ResetValues()
    {
        timer = 0;
        rand = Random.Range(0f, 10f);
        zeroTimer = 3;
        TripleZero.GetComponent<ZeroSpawner>().spawnCounter = 0;
        TripleZero.GetComponent<ZeroSpawner>().ZeroOne.SetActive(false);
        TripleZero.GetComponent<ZeroSpawner>().ZeroTwo.SetActive(false);
        TripleZero.GetComponent<ZeroSpawner>().ZeroThree.SetActive(false);

    }
}
