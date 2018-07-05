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
    RaycastHit2D[] hit = new RaycastHit2D[4];
    int i;
    float movescale = 10;
    float vectorscale = 0.15f;
    float detectionGain = 0.05f;
    public bool canUp, canDown, canLeft, canRight;
    
    enum Move{
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3
    }
    Move tryMove;
    Move qMove;

    // Use this for initialization
    void Start()
    {
        movement = new Vector2(0, 0);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        pos = transform.position;
        Vector2 v = rb.velocity;

        if (GetComponent<SwipeMovement>().swipeL)
        {
            movement = (Vector2.left);
            tryMove = Move.Left;
        }

        if (GetComponent<SwipeMovement>().swipeR)
        {
            movement = (Vector2.right);
            tryMove = Move.Right;
        }

        if (GetComponent<SwipeMovement>().swipeU)
        {
            movement = (Vector2.up);
            tryMove = Move.Up;
        }

        if (GetComponent<SwipeMovement>().swipeD)
        {
            movement = (Vector2.down);
            tryMove = Move.Down;
        }



        


        hit[0] = Physics2D.Linecast(pos + new Vector2(1f, 1f) * vectorscale, pos + movement * Time.deltaTime * movescale);
        hit[1] = Physics2D.Linecast(pos + new Vector2(-1f, 1f) * vectorscale, pos + movement * Time.deltaTime * movescale);
        hit[2] = Physics2D.Linecast(pos + new Vector2(1f, -1f) * vectorscale, pos + movement * Time.deltaTime * movescale);
        hit[3] = Physics2D.Linecast(pos + new Vector2(-1f, -1f) * vectorscale, pos + movement * Time.deltaTime * movescale);


        Debug.DrawRay(pos + new Vector2(1f, 1f) * vectorscale, movement * Time.deltaTime * movescale);
        Debug.DrawRay(pos + new Vector2(-1f, 1f) * vectorscale, movement * Time.deltaTime * movescale);
        Debug.DrawRay(pos + new Vector2(1f, -1f) * vectorscale, movement * Time.deltaTime * movescale);
        Debug.DrawRay(pos + new Vector2(-1f, -1f) * vectorscale, movement * Time.deltaTime * movescale);

        //if (queuedAction)
        //{
        //    RaycastHit2D qhit = Physics2D.Linecast(pos, pos + queuedMovement * Time.deltaTime * 10);
        //    Debug.DrawRay(pos, queuedMovement * Time.deltaTime * 10);

        //    if (qhit && qhit.collider.gameObject.tag == "Node")
        //    {
        //        if ((Vector2)qhit.collider.gameObject.transform.position == pos)
        //        {
        //            movement = queuedMovement;
        //            queuedAction = false;
        //            Debug.Log("Trigger Queued action");
        //        }
        //    }
           
        //}

        i = 0;
        while (i < 3)
        {

            if (hit[i])
            {
               // Debug.Log(hit[i].collider.gameObject.tag);
                if (hit[i].collider.gameObject.tag == "Wall")
                {
                    queuedMovement = movement;
                    qMove = tryMove;
                    movement = savedMovement;
                    queuedAction = true;
                    
                }
            }

            if (!hit[i])
            {

            }

            i++;
        }

        v = movement * Time.deltaTime * speed;
        savedMovement = movement;
        rb.velocity = v;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Node")
        {
            if (collision.transform.position.x < transform.position.x + detectionGain && collision.transform.position.x > transform.position.x - detectionGain)
            {
                Debug.Log("Same Coords");
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
                            if (canUp)
                            {
                                canAction = true;
                            }
                            else
                            {
                                canAction = false;
                            }
                            break;

                        case Move.Down:
                            if (canDown)
                            {
                                canAction = true;
                            }
                            else
                            {
                                canAction = false;
                            }
                            break;

                        case Move.Left:
                            if (canLeft)
                            {
                                canAction = true;
                            }
                            else
                            {
                                canAction = false;
                            }
                            break;

                        case Move.Right:
                            if (canRight)
                            {
                                canAction = true;
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
