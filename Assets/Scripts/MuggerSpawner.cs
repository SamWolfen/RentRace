using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuggerSpawner : MonoBehaviour
{

    int spawnCounter = 0;
    public float zeroTimer;
    public GameObject Mugger;
    public GameObject Mugger2;
    public GameObject TripleZero;
    public GameObject Police;
    public GameObject[] Nodes;
    int nodenum;
    float runTimer;
    public float timer;
    float spawnTimer;
    float rand = 0;
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
            //currently does nothing 
            switch (difficulty)
            {
                case DiffLevel.Easy:

                    break;

                case DiffLevel.Medium:
                    //TripleZeroSpawn();

                    break;
            }


            if (timer >= spawnCounter * 10 + 15)
            {
                // Mugger.GetComponent<Mugger>().isActive = false;
                //ResetValues();
                timer = 0;



            }

            if (timer > 3)
            {
                //this time period is the cool down between the player bing hit and the enemies resuming pursuit

                if (Mugger2.GetComponent<Mugger>().target == Nodes[nodenum].transform)
                {
                    Mugger2.GetComponent<Mugger>().target = Mugger2.GetComponent<Mugger>().Player.transform;
                    timer = 0;
                    
                    
                }

                if (Mugger.GetComponent<Mugger>().target != Mugger.GetComponent<Mugger>().Player.transform)
                {
                    Mugger.GetComponent<Mugger>().target = Mugger.GetComponent<Mugger>().Player.transform;
                    timer = 0;
                  
                }
            }

            if (timer >= 8)
            {
                // Mugger.GetComponent<Mugger>().isActive = false;
                //ResetValues();
                nodenum = Mathf.RoundToInt(Random.Range(0f, 3f));
                Debug.Log(nodenum);


                Mugger2.GetComponent<Mugger>().target = Nodes[nodenum].transform;
                timer = 0;

            }

            else
            {
                timer += Time.deltaTime * 1.0f;
            }
        }
        else
        {
            if (timer >= 5)
            {
                Mugger.GetComponent<Mugger>().isActive = true;
                Mugger2.GetComponent<Mugger>().isActive = true;
                spawnCounter++;


                ResetValues();

                //messily fix second enemy
                nodenum = Mathf.RoundToInt(Random.Range(0f, 3f));
                Debug.Log(nodenum);


                Mugger2.GetComponent<Mugger>().target = Nodes[nodenum].transform;


            }
            else
            {
                timer += Time.deltaTime * 1.0f;
            }
        }
    }

    void TripleZeroSpawn()
    {//leftovers from an initial idea where you could protect your properties be collecting 3 0's and then you become the police (like getting a power pellet in pac man)
        if (zeroTimer < timer)
        {
            zeroTimer += 2;
            TripleZero.GetComponent<ZeroSpawner>().spawnCounter++;
            TripleZero.GetComponent<ZeroSpawner>().SpawnZero();

        }
    }

    void ResetValues()
    {//resets all the nessicary values
        timer = 0;
        rand = Random.Range(0f, 10f);
        zeroTimer = 3;
        TripleZero.GetComponent<ZeroSpawner>().spawnCounter = 0;
        TripleZero.GetComponent<ZeroSpawner>().ZeroOne.SetActive(false);
        TripleZero.GetComponent<ZeroSpawner>().ZeroTwo.SetActive(false);
        TripleZero.GetComponent<ZeroSpawner>().ZeroThree.SetActive(false);

    }

    public void SendAway()
    {//when called, this code causes the enemys to stop pursuing the player
        nodenum = Mathf.RoundToInt(Random.Range(0f, 3f));
        Mugger2.GetComponent<Mugger>().target = Nodes[nodenum].transform;
        nodenum = Mathf.RoundToInt(Random.Range(0f, 3f));
        Mugger.GetComponent<Mugger>().target = Nodes[nodenum].transform;
        timer = 0;

        Mugger.GetComponent<BoxCollider2D>().enabled = false;
        Mugger2.GetComponent<BoxCollider2D>().enabled = false;



    }
}
