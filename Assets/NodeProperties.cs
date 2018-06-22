using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeProperties : MonoBehaviour
{

    // public GameObject ThisNode;

    //up, down, left, right
    public bool[] clear = new bool[4];
    //public GameObject otherNodetest;

    GameObject[] Neighbour = new GameObject[3];
    Vector2 pos;
    Vector2 direction;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        FindNeighbours();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FindNeighbours()
    {
        RaycastHit2D hit;
        int i = 0;

        while (i < 3)
        {
            switch (i)
            {
                case 0:
                    direction = Vector2.up;
                    break;
                case 1:
                    direction = Vector2.down;
                    break;
                case 2:
                    direction = Vector2.left;
                    break;
                case 3:
                    direction = Vector2.right;
                    break;
            }


            hit = Physics2D.Linecast(pos + direction, pos);
            if (hit.collider.gameObject.tag == "Node")
            {
                clear[i] = true;
                Neighbour[i] = hit.collider.gameObject;
            }

            i++;
        }
    }
}
