using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour {
    
    public Sprite[] Frames;

    Sprite CurrentSprite;
    public float rate;
    float frame;
    int frameInt;

    // Use this for initialization
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Frames[0];
        frame = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RefreshSprite();
    }

    public void RefreshSprite()
    {
        frame += Time.deltaTime * rate;
        if (frame > Frames.Length-1)
        {
            frame = 0;
        }
        frameInt = Mathf.RoundToInt(frame);
        CurrentSprite = Frames[frameInt];
        GetComponent<SpriteRenderer>().sprite = CurrentSprite;
    }

}
