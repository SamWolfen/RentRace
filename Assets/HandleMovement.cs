using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMovement : MonoBehaviour {
    public float speed;
    private int direction = 0;
    private Vector2 movement;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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


        transform.Translate(movement * Time.deltaTime * speed);

    }
}
