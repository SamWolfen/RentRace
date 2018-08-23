using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedActive : MonoBehaviour {
float count;
	// Use this for initialization
	void Start () {
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        count += Time.deltaTime;
        if (count >= 2)
            {
            count = 0;
            gameObject.SetActive(false);
        }
	}
}
