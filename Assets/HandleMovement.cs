using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMovement : MonoBehaviour
{
    public float speed;

    private Vector2 movement;
    private Vector2 savedMovement;
    private Vector2 pos;
    Rigidbody2D rb;


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
            savedMovement = (Vector2.left);
        }

        if (GetComponent<SwipeMovement>().swipeR)
        {
            savedMovement = (Vector2.right);
        }

        if (GetComponent<SwipeMovement>().swipeU)
        {
            savedMovement = (Vector2.up);
        }

        if (GetComponent<SwipeMovement>().swipeD)
        {
            savedMovement = (Vector2.down);
        }





        RaycastHit2D hit = Physics2D.Linecast(pos, pos + movement * Time.deltaTime * speed*2);

        if (hit)
        {
            if (hit.collider.gameObject.tag != "Wall")
            {
                movement = savedMovement;
            }
        }

        if (!hit)
        {
            movement = savedMovement;
        }
        movement = savedMovement;
        //transform.Translate(movement * Time.deltaTime * speed);
        v = movement * Time.deltaTime * speed;
        rb.velocity = v;
    }
}
