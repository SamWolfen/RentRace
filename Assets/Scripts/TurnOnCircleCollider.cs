using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnCircleCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var CircleCollider = GetComponent<CircleCollider2D>();
        CircleCollider.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
