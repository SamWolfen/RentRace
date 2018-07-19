using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMovement : MonoBehaviour
{
    public float speed;

    private Vector2 movement;
    private Vector2 savedMovement;
    private Vector2 queuedMovement;
    private Vector2 pos;
    Rigidbody2D rb;
    public bool queuedAction = false;
    bool canAction = false;
    RaycastHit2D[] hit = new RaycastHit2D[8];
    int i;
    float movescale = 0.25f;
    float vectorscale = 0.145f;
    float detectionGain = 0.01f;
    public bool canUp, canDown, canLeft, canRight;
    public bool hitUp, hitDown, hitLeft, hitRight;
    public bool blocked;
    public GameObject LastNode;
    int nodeNum;

    GameObject[] NextNode;


    public enum Move
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3
    }
    Move tryMove;
    Move hitSide;
    public Move qMove;

    // Use this for initialization
    void Start()
    {
        movement = new Vector2(0, 0);
        rb = gameObject.GetComponent<Rigidbody2D>();
        nodeNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (LastNode)
        {
            NextNode = LastNode.GetComponent<NodeProperties>().Neighbour;
        }

        pos = transform.position;
        Vector2 v = rb.velocity;


        if (GetComponent<SwipeMovement>().swipeL)
        {
            movement = (Vector2.left);
            tryMove = Move.Left;
            queuedAction = false;

            nodeNum = 2;
            Debug.Log(Vector2.MoveTowards(transform.position, NextNode[nodeNum].transform.position, 1f));
        }

        if (GetComponent<SwipeMovement>().swipeR)
        {
            movement = (Vector2.right);
            tryMove = Move.Right;
            queuedAction = false;

            nodeNum = 3;
            Debug.Log(Vector2.MoveTowards(transform.position, NextNode[nodeNum].transform.position, 1f));
        }

        if (GetComponent<SwipeMovement>().swipeU)
        {
            movement = (Vector2.up);
            tryMove = Move.Up;
            queuedAction = false;

            nodeNum = 0;
            Debug.Log(Vector2.MoveTowards(transform.position, NextNode[nodeNum].transform.position, 1f));
        }

        if (GetComponent<SwipeMovement>().swipeD)
        {
            movement = (Vector2.down);
            tryMove = Move.Down;
            queuedAction = false;

            nodeNum = 1;
            Debug.Log(Vector2.MoveTowards(transform.position, NextNode[nodeNum].transform.position, 1f));
        }

        if (LastNode && NextNode[nodeNum])
        {
            Debug.DrawRay(pos, NextNode[nodeNum].transform.position - transform.position, Color.yellow, 1f);
            movement = NextNode[nodeNum].transform.position - transform.position;
            movement = movement.normalized;
        }



        //top 
        hit[0] = Physics2D.Linecast(pos + new Vector2(1f, 1f) * vectorscale, pos + Vector2.up * movescale);
        hit[1] = Physics2D.Linecast(pos + new Vector2(-1f, 1f) * vectorscale, pos + Vector2.up * movescale);
        //bottom
        hit[2] = Physics2D.Linecast(pos + new Vector2(1f, -1f) * vectorscale, pos + Vector2.down * movescale);
        hit[3] = Physics2D.Linecast(pos + new Vector2(-1f, -1f) * vectorscale, pos + Vector2.down * movescale);
        //left
        hit[4] = Physics2D.Linecast(pos + new Vector2(-1f, 1f) * vectorscale, pos + Vector2.left * movescale);
        hit[5] = Physics2D.Linecast(pos + new Vector2(-1f, -1f) * vectorscale, pos + Vector2.left * movescale);
        // right
        hit[6] = Physics2D.Linecast(pos + new Vector2(1f, 1f) * vectorscale, pos + Vector2.right * movescale);
        hit[7] = Physics2D.Linecast(pos + new Vector2(1f, -1f) * vectorscale, pos + Vector2.right * movescale);


        Debug.DrawRay(pos + new Vector2(1f, 1f) * vectorscale, Vector2.up * movescale);
        Debug.DrawRay(pos + new Vector2(-1f, 1f) * vectorscale, Vector2.up * movescale);

        Debug.DrawRay(pos + new Vector2(1f, -1f) * vectorscale, Vector2.down * movescale);
        Debug.DrawRay(pos + new Vector2(-1f, -1f) * vectorscale, Vector2.down * movescale);

        Debug.DrawRay(pos + new Vector2(-1f, 1f) * vectorscale, Vector2.left * movescale);
        Debug.DrawRay(pos + new Vector2(-1f, -1f) * vectorscale, Vector2.left * movescale);

        Debug.DrawRay(pos + new Vector2(1f, 1f) * vectorscale, Vector2.right * movescale);
        Debug.DrawRay(pos + new Vector2(1f, -1f) * vectorscale, Vector2.right * movescale);


        //Debug.DrawRay(pos + new Vector2(-1f, 1f) * vectorscale, movement * Time.deltaTime * movescale);
        //Debug.DrawRay(pos + new Vector2(1f, -1f) * vectorscale, movement * Time.deltaTime * movescale);
        //Debug.DrawRay(pos + new Vector2(-1f, -1f) * vectorscale, movement * Time.deltaTime * movescale);

        if (queuedAction)
        {
            RaycastHit2D qhit = Physics2D.Linecast(pos, pos + queuedMovement * Time.deltaTime * 10);
            Debug.DrawRay(pos, queuedMovement * Time.deltaTime * 10);
        }


        //trying to improve detection
        #region Trying to fix wall detection

        //top


        if (hit[0])
        {
            if (hit[0].collider.gameObject.tag == "Wall")
            {
                hitUp = true;
            }

        }

        if (hit[1])
        {
            if (hit[1].collider.gameObject.tag == "Wall")
            {

                hitUp = true;
            }

        }

        if (!hit[0] && !hit[1])
        {
            hitUp = false;
        }
        if (hit[0] && hit[1])
        {
            if (hit[0].collider.gameObject.tag != "Wall" && hit[1].collider.gameObject.tag != "Wall")
            {
                hitUp = false;
            }
        }

        //botom
        if (hit[2])
        {
            if (hit[2].collider.gameObject.tag == "Wall")
            {
                hitDown = true;
            }

        }

        if (hit[3])
        {
            if (hit[3].collider.gameObject.tag == "Wall")
            {

                hitDown = true;
            }

        }

        if (!hit[2] && !hit[3])
        {
            hitDown = false;
        }
        if (hit[2] && hit[3])
        {
            if (hit[2].collider.gameObject.tag != "Wall" && hit[3].collider.gameObject.tag != "Wall")
            {
                hitUp = false;
            }
        }


        //left
        if (hit[4])
        {
            if (hit[4].collider.gameObject.tag == "Wall")
            {
                hitLeft = true;
            }

        }

        if (hit[5])
        {
            if (hit[5].collider.gameObject.tag == "Wall")
            {

                hitLeft = true;
            }

        }

        if (!hit[4] && !hit[5])
        {
            hitLeft = false;
        }
        if (hit[4] && hit[5])
        {
            if (hit[4].collider.gameObject.tag != "Wall" && hit[5].collider.gameObject.tag != "Wall")
            {
                hitLeft = false;
            }
        }

        //Right
        if (hit[6])
        {
            if (hit[6].collider.gameObject.tag == "Wall")
            {
                hitRight = true;
            }

        }

        if (hit[7])
        {
            if (hit[7].collider.gameObject.tag == "Wall")
            {

                hitRight = true;
            }

        }

        if (!hit[6] && !hit[7])
        {
            hitRight = false;
        }
        if (hit[6] && hit[7])
        {
            if (hit[6].collider.gameObject.tag != "Wall" && hit[7].collider.gameObject.tag != "Wall")
            {
                hitRight = false;
            }
        }




        #endregion


        //determine if the player is blocked
        blocked = false;
        
        switch (tryMove)
        {
            case Move.Up:
                if (hit[0])
                {
                    if (hit[0].collider.gameObject.tag == "Wall")
                    {
                        blocked = true;
                    }


                }

                if (hit[1])
                {
                    if (hit[1].collider.gameObject.tag == "Wall")
                    {
                        blocked = true;
                    }

                }


                break;

            case Move.Down:
                if (hit[2])
                {
                    if (hit[2].collider.gameObject.tag == "Wall")
                    {
                        blocked = true;
                    }


                }

                if (hit[3])
                {
                    if (hit[3].collider.gameObject.tag == "Wall")
                    {
                        blocked = true;
                    }

                }




                break;

            case Move.Left:
                if (hit[4])
                {
                    if (hit[4].collider.gameObject.tag == "Wall")
                    {
                        blocked = true;
                    }


                }

                if (hit[5])
                {
                    if (hit[5].collider.gameObject.tag == "Wall")
                    {
                        blocked = true;
                    }

                }

                break;

            case Move.Right:
                if (hit[6])
                {
                    if (hit[6].collider.gameObject.tag == "Wall")
                    {
                        blocked = true;
                    }


                }

                if (hit[7])
                {
                    if (hit[7].collider.gameObject.tag == "Wall")
                    {
                        blocked = true;
                    }

                }
                break;

        }


        if (blocked == true)
        {
            queuedMovement = movement;
            qMove = tryMove;
            movement = savedMovement;
            queuedAction = true;
            blocked = false;
        }


        v = movement * Time.deltaTime * speed;
        savedMovement = movement;
        rb.velocity = v;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        //if pos plus vector is moving away from center of node exceute?


        if (collision.tag == "Node")
        {
            LastNode = collision.gameObject;

            if ((collision.transform.position.x < transform.position.x + detectionGain && collision.transform.position.x > transform.position.x - detectionGain) || (collision.transform.position.x < transform.position.y + detectionGain && collision.transform.position.x > transform.position.y - detectionGain))
            {
                //Debug.Log("Same Coords");
                var clear = collision.GetComponent<NodeProperties>().clear;

                canUp = clear[0];
                canDown = clear[1];
                canLeft = clear[2];
                canRight = clear[3];


                if (queuedAction)
                {
                    switch (qMove)
                    {
                        case Move.Up:
                            if (canUp && !hitUp)
                            {
                                canAction = true;
                                queuedMovement = Vector2.up;

                            }
                            else
                            {
                                canAction = false;
                            }
                            break;

                        case Move.Down:
                            if (canDown && !hitDown)
                            {
                                canAction = true;
                                queuedMovement = Vector2.down;
                            }
                            else
                            {
                                canAction = false;
                            }
                            break;

                        case Move.Left:
                            if (canLeft && !hitLeft)
                            {
                                canAction = true;
                                queuedMovement = Vector2.left;
                            }
                            else
                            {
                                canAction = false;
                            }
                            break;

                        case Move.Right:
                            if (canRight && !hitRight)
                            {
                                canAction = true;
                                queuedMovement = Vector2.right;
                            }
                            else
                            {
                                canAction = false;
                            }
                            break;
                    }


                    if (canAction)
                    {
                        movement = queuedMovement;
                        queuedAction = false;
                        Debug.Log("Trigger Queued action");
                    }
                }
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Node")
        {
            canUp = false;
            canDown = false;
            canLeft = false;
            canRight = false;

        }
    }


}
