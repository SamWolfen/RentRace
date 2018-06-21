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
    enum ObstructedSide
    {
        Up = 1, Down = 2, Left = 3, Right = 4
    }

    ObstructedSide obstructedSide;


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
                        try
                        {
                            Target = FindNearestTarget(Pather, 1, "Coin");
                            Pather.GetComponent<RealEstateAgent>().AgentBubbleToggle(false);
                        }
                        catch
                        {
                            Debug.Log("No Coins Found");
                        }

                        if (Target == Pather)
                        {
                            Pather.GetComponent<RealEstateAgent>().AgentBubbleToggle(true);
                            Target = FindNearestTarget(Pather, 1, "HiredAgency");
                        }

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

        potentialTargets = GameObject.FindGameObjectsWithTag(specificTag);

        if (potentialTargets.Length > 0)
        {

            GameObject ReturnedTarget = GameObject.FindGameObjectWithTag(specificTag);




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
        else
        {
            return Pather;
        }


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


        if (TestObstructed(Pather.transform.position, direction))
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


    // ***********************************************************
    void FindRoute(GameObject target)
    {

        Vector2 testpos = transform.position;
        Vector2[] waypoints = new Vector2[15];
        int i = 0;


        while (i < 15 || testpos != (Vector2)target.transform.position)
        {
            //check obstructed
            if (TestObstructed(Pather.transform.position, direction))
            {
                if (direction == Vector2.up)
                {
                    obstructedSide = ObstructedSide.Up;
                }
                else if (direction == Vector2.down)
                {
                    obstructedSide = ObstructedSide.Down;
                }
                else if (direction == Vector2.left)
                {
                    obstructedSide = ObstructedSide.Left;
                }
                else if (direction == Vector2.right)
                {
                    obstructedSide = ObstructedSide.Right;
                }






                switch (obstructedSide)
                {

                    case ObstructedSide.Up:
                        //check along x
                        while (obstructedSide == ObstructedSide.Up)
                        {
                            testpos += Vector2.right;
                            TestObstructed(testpos, direction);
                        }

                        waypoints[i] = testpos;

                        break;

                    case ObstructedSide.Down:
                        //check along x

                        break;
                    case ObstructedSide.Left:
                        //check along y

                        break;
                    case ObstructedSide.Right:
                        //check along y

                        break;
                }



                //figure out which side obstacle is on

                //if obstacle is on left or right, check various coords on y until clear. if y is obstructed, go other way along y
                //eventually a way will be clear along x (assuming x was blocked)
                //when this happens drop a waypoint and repeat until the waypoints lead to the target.

                // at some point if theres multiple paths then we will have to find the shortest one :/

                testpos = new Vector2(testpos.x, testpos.y);

            }
        }





    }
    public bool TestObstructed(Vector2 pos, Vector2 Move)
    {

        RaycastHit2D hit = Physics2D.Linecast(pos + Move, pos);
        if (hit.collider.gameObject.tag == "Wall")
        {
            return (hit.collider == GetComponent<Collider2D>());
        }

        return false;
    }



}
