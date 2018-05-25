using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PullScore : MonoBehaviour {
    public GameObject Player;
    private Text text;
    private ScoreHolder scores;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        text = GetComponent<Text>();
        scores = Player.GetComponent<ScoreHolder>();
        text.text = "Total Money: " + scores.Score;
    }
}
