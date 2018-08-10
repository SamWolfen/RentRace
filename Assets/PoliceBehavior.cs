using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceBehavior : MonoBehaviour {
    public bool isActive;
    public bool isDeactivated;
    public bool isActivated;

    // Use this for initialization
    void Start () {
        Activate(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (isActive)
        {

        }
		
	}

    void Activate(bool ActDe)
    {
        //if actde is true then we are activationg the object, if not then we are deactivating the object
        if (ActDe)
        {

            isActivated = true;
            isDeactivated = false;
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;

        }
        else
        {
            isActivated = false;
            isDeactivated = true;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            //GetComponent<Pathfinding.AIDestinationSetter>().target = MuggerSpawn.transform;

        }
    }
}
