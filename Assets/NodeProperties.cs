using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum Direction
{
    up = 0,
    down = 1,
    left = 2,
    right = 3
}

public class NodeProperties : MonoBehaviour
{

    // public GameObject ThisNode;

    //up, down, left, right
    public bool[] clear = new bool[4];


    public GameObject[] Neighbour = new GameObject[4];
    static Vector2 pos;
    Vector2 direction;
    public Collider2D[] allNodesp;
    public float[] distScore = new float[4];
    PathFinding Pathfinder;
    public float cost;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < distScore.Length; i++)
        {
            distScore[i] = 100;
        }
        pos = transform.position;
        allNodesp = Physics2D.OverlapCircleAll(pos, 2.0f);
        FindNeighbours();

        

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FindNeighbours()
    {
        RaycastHit2D hit;
        Collider2D[] allNodes = Physics2D.OverlapCircleAll(pos, 4.0f);

        int i = 0;
        int n = 0;





        while (i < allNodes.Length)
        {
            if (allNodes[i].tag == "Node")
            {
                hit = Physics2D.Linecast(pos, allNodes[i].transform.position);
                if (hit)
                {
                    if (hit.collider.gameObject.name == allNodes[i].name)
                    {
                        Vector2 dir = (Vector2)allNodes[i].transform.position - pos;

                        n = DefineDirection(dir);


                        clear[n] = true;
                        Neighbour[n] = hit.collider.gameObject;

                    }
                }
            }

            i++;
        }

         n = 0;

        while (n < distScore.Length)
        {
            if (clear[n])
            {
                distScore[n] = Vector2.Distance(pos, Neighbour[n].transform.position);
            }
            n++;

        }


    }



    private int DefineDirection(Vector2 Test)
    {
        Direction dir = Direction.right;
        int result = 0;


        if (Test.x >= 0)
        {
            //moving right

            if (Test.y >= 0)
            {
                if (Test.x > Test.y)
                {
                    //moving right?
                    dir = Direction.right;

                }

                if (Test.x < Test.y)
                {
                    //moving up?
                    dir = Direction.up;
                }
            }

            if (Test.y <= 0)
            {


                if (Test.x > Test.y * -1)
                {
                    //moving right?
                    dir = Direction.right;

                }

                if (Test.x < Test.y * -1)
                {
                    //moving down?
                    dir = Direction.down;
                }
            }
        };

        if (Test.x <= 0)
        {
            //moving left


            if (Test.y >= 0)
            {
                if (Test.x * -1 > Test.y)
                {
                    //moving left?
                    dir = Direction.left;

                }

                if (Test.x * -1 < Test.y)
                {
                    //moving up?
                    dir = Direction.up;
                }
            }

            if (Test.y <= 0)
            {


                if (Test.x * -1 > Test.y * -1)
                {
                    //moving left?
                    dir = Direction.left;

                }

                if (Test.x * -1 < Test.y * -1)
                {
                    //moving down?
                    dir = Direction.down;
                }
            }




        };

        switch (dir)
        {
            case Direction.up:
                result = 0;
                break;
            case Direction.down:
                result = 1;
                break;
            case Direction.left:
                result = 2;
                break;
            case Direction.right:
                result = 3;
                break;
        }


        return result;
    }

}
