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
    bool queuedAction = false;


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
        }

        if (GetComponent<SwipeMovement>().swipeR)
        {
            movement = (Vector2.right);
        }

        if (GetComponent<SwipeMovement>().swipeU)
        {
            movement = (Vector2.up);
        }

        if (GetComponent<SwipeMovement>().swipeD)
        {
            movement = (Vector2.down);
        }



        //if (queuedAction)
        //{
        //    RaycastHit2D qhit = Physics2D.Linecast(pos, pos + queuedMovement * Time.deltaTime * 10);
        //    Debug.DrawRay(pos, queuedMovement * Time.deltaTime * 10);

        //    if (qhit)
        //    {
        //        if (qhit.collider.gameObject.tag != "Wall")
        //            {
        //            movement = queuedMovement;
        //            }
        //    }
        //    else
        //    {
        //        movement = queuedMovement;
        //    }
        //}

        RaycastHit2D hit = Physics2D.Linecast(pos, pos + movement * Time.deltaTime * 20);
        Debug.DrawRay(pos, movement * Time.deltaTime * 20);




        if (hit)
        {
            Debug.Log(hit.collider.gameObject.tag);
            if (hit.collider.gameObject.tag == "Wall")
            {
                queuedMovement = movement;
                movement = savedMovement;
                queuedAction = true;

            }
        }

        if (!hit)
        {

        }
        //movement = savedMovement;
        //transform.Translate(movement * Time.deltaTime * speed);
        v = movement * Time.deltaTime * speed;
        savedMovement = movement;
        rb.velocity = v;
    }
}
