using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PathFinding : MonoBehaviour
{

    //public GameObject Player;
    public GameObject Pather;
    int RandomHolder;
    GameObject[] PotentialTargets = new GameObject[150];
    GameObject Target;
    public Vector2 TestDirection = new Vector2(0, 0);
    public Vector2 direction = new Vector2(0, 0);
    public float speed;



    // Use this for initialization
    void Start()
    {
        RandomHolder = Random.Range(1, 4);
        StartCoroutine(AIPathFinding(RandomHolder));
        StartCoroutine(Refiner());
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator AIPathFinding(int RandomHolder)
    {
        bool looping = true;

        Target = Pather;

        switch (RandomHolder)
        {
            case 1:
                direction = new Vector2(0, 1);
                break;

            case 2:
                direction = new Vector2(0, -1);
                break;

            case 3:
                direction = new Vector2(1, 0);
                break;

            case 4:
                direction = new Vector2(-1, 0);
                break;
        }


        while (looping == true)
        {
            yield return new WaitForEndOfFrame();

            ///Find Nearest Object
            ///
            switch (Pather.tag)
            {
                case "Enemy":
                    Target = FindNearestTarget(Pather, 1, "Player");
                    break;
                case "Agent":
                    Target = FindNearestTarget(Pather, 1, "Coin");
                    break;
            }


            
            ///Move towards
            Pursue(Target);
        }

    }

    void Pursue(GameObject target)
    {

        transform.Translate(direction * Time.deltaTime * speed);
        return;
    }

    public GameObject FindNearestTarget(GameObject Caller, float Radius, string specificTag)
    {
        //finds Objects in a radius, and can filter for a specific tag, returns closest

        GameObject ReturnedTarget = GameObject.FindGameObjectWithTag(specificTag);
        //
        //GameObject TestTarget;




        PotentialTargets = GameObject.FindGameObjectsWithTag(specificTag);
        
    
        


        foreach (GameObject TestObject in PotentialTargets)
        {
            //compares distances, keeps the closest one
            if (Vector3.Distance(Caller.transform.position, TestObject.transform.position) <= Vector3.Distance(Caller.transform.position, ReturnedTarget.transform.position))
            {
                ReturnedTarget = TestObject;
            }
        }



        return ReturnedTarget;
    }


    private void RefineDirection(Vector2 Test)
    {



        if (Test.x > 0)
        {
            //moving right

            if (Test.y > 0)
            {
                if (Test.x > Test.y)
                {
                    //moving right?
                    direction = new Vector2(1, 0);

                }

                if (Test.x < Test.y)
                {
                    //moving up?
                    direction = new Vector2(0, 1);
                }
            }

            if (Test.y < 0)
            {


                if (Test.x > Test.y * -1)
                {
                    //moving right?
                    direction = new Vector2(1, 0);

                }

                if (Test.x < Test.y * -1)
                {
                    //moving down?
                    direction = new Vector2(0, -1);
                }
            }
        };

        if (Test.x < 0)
        {
            //moving left


            if (Test.y > transform.localPosition.y)
            {
                if (Test.x * -1 > Test.y)
                {
                    //moving left?
                    direction = new Vector2(-1, 0);

                }

                if (Test.x * -1 < Test.y)
                {
                    //moving up?
                    direction = new Vector2(0, 1);
                }
            }

            if (Test.y < 0)
            {


                if (Test.x * -1 > Test.y * -1)
                {
                    //moving left?
                    direction = new Vector2(-1, 0);

                }

                if (Test.x * -1 < Test.y * -1)
                {
                    //moving down?
                    direction = new Vector2(0, -1);
                }
            }
        };


    }


    IEnumerator Refiner()
    {
        bool loop = true;
        while (loop)
        {
            yield return new WaitForSecondsRealtime(0.5f);

            TestDirection = Target.transform.position - transform.position;
            RefineDirection(TestDirection.normalized);
        }

    }

}
