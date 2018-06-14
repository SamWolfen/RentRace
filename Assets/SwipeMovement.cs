using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMovement : MonoBehaviour {

    public bool tap, swipeL, swipeR, swipeU, swipeD;
    private bool isDragging = false;
    Vector2 startTouch, swipeDelta;

    private void Update()
    {
        tap = swipeL = swipeR = swipeU = swipeD = false;

        //mouse
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            Debug.Log("tap happened");
            startTouch = Input.mousePosition;
            isDragging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Reset();
        }

        //Mobile Input
        if (Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                Debug.Log("tap happened");
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            } else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Reset();
                
            }
        }


        //calc distance
        swipeDelta = Vector2.zero;
        if (isDragging)
        {
            
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        //cross deadzone
        if (swipeDelta.magnitude > 5)
        {
            Debug.Log("dragging happened");
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                //horizontal
                if (x<0)
                {
                    swipeL = true;
                    Debug.Log("Left drag");
                }
                else
                {
                    swipeR = true;
                    Debug.Log("right drag");
                }

            }else {
                //vertical
                if (y < 0)
                {
                    swipeD = true;
                }
                else
                {
                    swipeU = true;
                }
            }

            Reset();
        }


    }

    private void Reset()
    {
        startTouch = Vector2.zero;
        isDragging = false;
    }
}
