using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour {
    public enum Facing
    {
        Up,Down,Left,Right
    }

    public Facing facing;
    public  Sprite sprUp, sprDown;
    public Sprite[] sprRight;
    Sprite[] sprLeft;




    Sprite CurrentSprite;
    float rate = 15;
    float frame;
    int frameInt;

	// Use this for initialization
	void Start () {
        facing = Facing.Down;
        GetComponent<SpriteRenderer>().sprite = sprDown;
        frame = 0;
        sprLeft = sprRight;
       

    }
	
	// Update is called once per frame
	void Update () {

		
	}

    public void RefreshSprite()
    {
        frame += Time.deltaTime*rate;
        if (frame > 3)
        {
            frame = 0;
        }
        frameInt = Mathf.RoundToInt(frame);

        switch (facing)
        {
            case Facing.Up:
                CurrentSprite = sprUp;
                break;

            case Facing.Down:
                CurrentSprite = sprDown;
                break;

            case Facing.Left:
                CurrentSprite = sprRight[frameInt];
                GetComponent<SpriteRenderer>().flipX = true;
                break;

            case Facing.Right:
                CurrentSprite = sprRight[frameInt];
                GetComponent<SpriteRenderer>().flipX = false;
                break;
        }
        GetComponent<SpriteRenderer>().sprite = CurrentSprite;
    }
}
