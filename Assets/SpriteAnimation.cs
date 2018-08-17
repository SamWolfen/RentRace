using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour {
    
    public Sprite[] coinFrames;

    Sprite CurrentSprite;
    float rate = 5;
    float frame;
    int frameInt;

    // Use this for initialization
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = coinFrames[0];
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
        if (frame > coinFrames.Length-1)
        {
            frame = 0;
        }
        frameInt = Mathf.RoundToInt(frame);
        CurrentSprite = coinFrames[frameInt];
        GetComponent<SpriteRenderer>().sprite = CurrentSprite;
    }

}
