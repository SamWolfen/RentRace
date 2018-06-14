using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PathFinding : MonoBehaviour
{

    //public GameObject Player;
    public GameObject Pather;
    int randomHolder;
    GameObject[] potentialTargets = new GameObject[150];
    public GameObject Target;
    public Vector2 testDirection = new Vector2(0, 0);
    public Vector2 direction = new Vector2(0, 0);
    public float speed;



    // Use this for initialization
    void Start()
    {
        Activated();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activated()
    {
        randomHolder = Random.Range(1, 4);
        StartCoroutine(AIPathFinding(randomHolder));
        StartCoroutine(Refiner());
    }

    IEnumerator AIPathFinding(int RandomHolder)
    {
        bool looping = true;

        Target = Pather;

        //switch (randomHolder)
        //{
        //    case 1:
        //        direction = new Vector2(0, 1);
        //        break;

        //    case 2:
        //        direction = new Vector2(0, -1);
        //        break;

        //    case 3:
        //        direction = new Vector2(1, 0);
        //        break;

        //    case 4:
        //        direction = new Vector2(-1, 0);
        //        break;
        //}


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

                    if (Pather.GetComponent<RealEstateAgent>().gatheredCoins >= Pather.GetComponent<RealEstateAgent>().maxCoins)
                    {
                        Target = FindNearestTarget(Pather, 1, "HiredAgency");
                    }
                    else
                    {
                        Target = FindNearestTarget(Pather, 1, "Coin");
                    }
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
        GameObject ReturnedTarget = GameObject.FindGameObjectWithTag(specificTag);   
        potentialTargets = GameObject.FindGameObjectsWithTag(specificTag);
       
        foreach (GameObject TestObject in potentialTargets)
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


        if (TestObstructed(Pather, direction))
        {
            RefineDirection(new Vector2(Test.y, Test.x));
        }

        //direction /= 2;
        return;
    }


    IEnumerator Refiner()
    {
        bool loop = true;
        while (loop)
        {
            yield return new WaitForSecondsRealtime(0.5f);

            testDirection = Target.transform.position - transform.position;
           RefineDirection(testDirection.normalized);
        }

    }

    public bool TestObstructed(GameObject Caller, Vector2 Move)
    {
        Vector2 pos = Caller.transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + Move, pos);
        if (hit.collider.gameObject.tag == "Wall")
        {
            return (hit.collider == GetComponent<Collider2D>());
        }

        return false;
    }

}
