using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PathFinding : MonoBehaviour
{

    public GameObject Player;
    public GameObject Pather;
    int RandomHolder;
    GameObject[] PotentialTargets = new GameObject[150];
    Vector2 TestDirection = new Vector2(0, 0);
    public Vector2 direction = new Vector2(0, 0);



    // Use this for initialization
    void Start()
    {
        RandomHolder = Random.Range(1, 4);
        StartCoroutine(AIPathFinding(RandomHolder));
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator AIPathFinding(int RandomHolder)
    {
        bool looping = true;
        
        GameObject Target;

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
            Target = FindNearestTarget(Pather, 1, "Player");
            ///Move towards
            Pursue(Target);
        }
        
    }

    void Pursue(GameObject target)
    {
        TestDirection = target.transform.position - transform.position;
        //RefineDirection(TestDirection.normalized);
        transform.Translate(TestDirection.normalized * Time.deltaTime);

        

        

        return;
    }

    public GameObject FindNearestTarget(GameObject Caller, float Radius, [Optional] string specificTag)
    {
        //finds Objects in a radius, and can filter for a specific tag, returns closest

        GameObject ReturnedTarget = Player;
        //
        //GameObject TestTarget;
        

        if (specificTag != null)
        {
            PotentialTargets = GameObject.FindGameObjectsWithTag(specificTag);
        }
        else
        {
            PotentialTargets = FindObjectsOfType<GameObject>();
        }


        foreach (GameObject Object in PotentialTargets)
        {
            if (ReturnedTarget == null)
            {
                ReturnedTarget = Object;
            }
            //compares distances, keeps the closest one
            if (Vector3.Distance(Caller.transform.position, Object.transform.position) <= Vector3.Distance(Caller.transform.position, ReturnedTarget.transform.position))
            {
                ReturnedTarget = Object;
            }
        }
        
        

        return ReturnedTarget;
    }


    private void RefineDirection(Vector2 Test)
    {



        if (Test.x > transform.localPosition.x)
        {
            //moving right

            if (Test.y > transform.localPosition.y)
            {
                if (Test.x > Test.y)
                {
                    //moving right?
                    direction = new Vector2(-1, 0);
                    
                }

                if (Test.x < Test.y)
                {
                    //moving up?
                    direction = new Vector2(0, -1);
                }
            }

            if (Test.y < transform.localPosition.y)
            {
                

                if (Test.x > Test.y * -1)
                {
                    //moving right?
                    direction = new Vector2(-1, 0);

                }

                if (Test.x < Test.y * -1)
                {
                    //moving down?
                    direction = new Vector2(0, 1);
                }
            }
        };

        if (Test.x < transform.localPosition.x)
        {
            //moving left
            

            if (Test.y > transform.localPosition.y)
            {
                if (Test.x * -1 > Test.y)
                {
                    //moving left?
                    direction = new Vector2(1, 0);

                }

                if (Test.x * -1 < Test.y)
                {
                    //moving up?
                    direction = new Vector2(0, -1);
                }
            }

            if (Test.y < transform.localPosition.y)
            {
                

                if (Test.x * -1 > Test.y * -1)
                {
                    //moving left?
                    direction = new Vector2(1, 0);

                }

                if (Test.x * -1 < Test.y * -1)
                {
                    //moving down?
                    direction = new Vector2(0, 1);
                }
            }
        };

        
    }


}
