using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mugger : MonoBehaviour {
    public bool isActive;
    public bool isDeactivated;
    public bool isActivated;
    public GameObject Player;
    public GameObject MuggerSpawn;
    public Transform target;
    enum State
    {
        chase,
        retreat
    }

    State state;

    // Use this for initialization
    void Start () {
        Activate(false);
        target = Player.transform;

	}
	
	// Update is called once per frame
	void Update () {
        if (isActive)
        {
            GetComponent<Pathfinding.AIDestinationSetter>().target = target;

            if(target == MuggerSpawn.transform)
            {
                target = Player.transform;
            }


            if (!isActivated)
            {
                //activate
                Activate(true);
                
            }

        }
        else if (!isDeactivated)
        {
            //deactivate
            Activate(false);
        }
	}


    //activates and deactivates object. consider this as a start/stop funciton that deals with all the nessicary values as actually deactivating the object is bad practice.
    void Activate(bool ActDe)
    {
        MuggerSpawn.GetComponent<MuggerSpawner>().timer = 0;


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
            GetComponent<Pathfinding.AIDestinationSetter>().target = MuggerSpawn.transform;

        }
    }

    
}
