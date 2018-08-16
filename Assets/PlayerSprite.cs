using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour {
    public enum Facing
    {
        Up,Down,Left,Right
    }

    public Facing facing;
    public Sprite sprUp, sprDown, sprLeft, sprRight;
    Sprite CurrentSprite;

	// Use this for initialization
	void Start () {
        facing = Facing.Down;
        GetComponent<SpriteRenderer>().sprite = sprDown;
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    public void RefreshSprite()
    {
        switch (facing)
        {
            case Facing.Up:
                CurrentSprite = sprUp;
                break;

            case Facing.Down:
                CurrentSprite = sprDown;
                break;

            case Facing.Left:
                CurrentSprite = sprLeft;
                break;

            case Facing.Right:
                CurrentSprite = sprRight;
                break;
        }
        GetComponent<SpriteRenderer>().sprite = CurrentSprite;
    }
}
