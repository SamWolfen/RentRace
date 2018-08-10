using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceLightColours : MonoBehaviour
{
    Color colour;
    SpriteRenderer spriteRenderer;
    float pauto;
    bool turnRed, turnBlue, fading;
    public float intensity, rate;




    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colour = spriteRenderer.color;
        turnRed = true;
        turnBlue = false;
        intensity = 0;
        colour[1] = 0;
        rate = rate / 100;
    }

    // Update is called once per frame
    void Update()
    {
        //if (turnRed)
        //{

        //    if (intensity < 1 && fading == false)
        //    {
        //        intensity += rate;

        //    }
        //    else if (intensity >= 1 && fading == false)
        //    {
        //        fading = true;
        //    }


        //    if (intensity > 0 && fading == true)
        //    {
        //        intensity -= rate;

        //    }
        //    else if (intensity <= 0 && fading == true)
        //    {
        //        fading = false;
        //        turnRed = false;
        //        turnBlue = true;
        //    }

        //    colour[0] = 1;
        //    colour[2] = 0;
        //    colour[3] = intensity;


        //}
        //else if (turnBlue)
        //{
        //    if (intensity < 1 && fading == false)
        //    {
        //        intensity += rate;

        //    }
        //    else if (intensity >= 1 && fading == false)
        //    {
        //        fading = true;
        //    }


        //    if (intensity > 0 && fading == true)
        //    {
        //        intensity -= rate;

        //    }
        //    else if (intensity <= 0 && fading == true)
        //    {
        //        fading = false;
        //        turnRed = true;
        //        turnBlue = false;
        //    }

        //    colour[0] = 0;
        //    colour[2] = 1;
        //    colour[3] = intensity;
        //}

        if (intensity < 1 && fading == false)
        {
            intensity += rate;

        }
        else if (intensity >= 1 && fading == false)
        {
            fading = true;
        }


        if (intensity > 0 && fading == true)
        {
            intensity -= rate;

        }
        else if (intensity <= 0 && fading == true)
        {
            fading = false;
            if (turnRed == true)
            { 
                turnBlue = true;
                turnRed = false;
            }
            else if (turnBlue == true)
            {
                turnBlue = false;
                turnRed = true;
            }
        }

        colour[0] = 0;
        colour[2] = 1;
        colour[3] = intensity;

        if (turnRed)
        {
            colour[2] = 0;
            colour[0] = 1;
        }

        if (turnBlue)
        {
            colour[2] = 1;
            colour[0] = 0;
        }

        spriteRenderer.color = colour;

    }
}
