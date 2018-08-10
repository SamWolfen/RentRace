using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceBehavior : MonoBehaviour {
    public bool isActive;
    public bool isDeactivated;
    public bool isActivated;
    Vector2 pos;

    // Use this for initialization
    void Start () {
        Activate(false);
        pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (isActive)
        {
            //
            Vector2.MoveTowards(transform.position, new Vector2 (0, 0), 1);
        }
		
	}

    void Activate(bool ActDe)
    {
        //if actde is true then we are activationg the object, if not then we are deactivating the object
        if (ActDe)
        {

            isActivated = ActDe;
            isActive = ActDe;
            isDeactivated = !ActDe;
            GetComponent<SpriteRenderer>().enabled = ActDe;
            GetComponent<BoxCollider2D>().enabled = ActDe;
            GetComponentInChildren<SpriteRenderer>().enabled = ActDe;

        }
        else
        {
            isActivated = ActDe;
            isDeactivated = !ActDe;
            GetComponent<SpriteRenderer>().enabled = ActDe;
            GetComponent<BoxCollider2D>().enabled = ActDe;
            GetComponentInChildren<SpriteRenderer>().enabled = ActDe;
            //GetComponent<Pathfinding.AIDestinationSetter>().target = MuggerSpawn.transform;
            //reset positon
            transform.position = pos;

        }
    }
}
