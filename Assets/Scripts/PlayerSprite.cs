using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour {
    public enum Facing
    {
        Up,Down,Left,Right
    }

    public Facing facing;
    
    public Sprite[] sprRight;
    public Sprite[] sprUp;
    public Sprite[] sprDown;
    //Sprite[] sprLeft;




    Sprite CurrentSprite;
    public float rate;
    float frame;
    int frameInt;

	// Use this for initialization
	void Start () {
        facing = Facing.Down;
        GetComponent<SpriteRenderer>().sprite = sprDown[0];
        frame = 0;
        //sprLeft = sprRight;
       

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
                CurrentSprite = sprUp[frameInt];
                break;

            case Facing.Down:
                CurrentSprite = sprDown[frameInt];
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
