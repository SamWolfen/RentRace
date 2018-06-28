using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DijkstraPathing : MonoBehaviour {
    GameObject[] Nodes = new GameObject[101];
    List<GameObject> UncheckedNodes = new List<GameObject>();
    float Path = 0;
    


	// Use this for initialization
	void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {
		
	}
     public GameObject[] FindNodePath(GameObject Start, GameObject End)
    {
        Nodes = GameObject.FindGameObjectsWithTag("Node");
        //UncheckedNodes = Nodes;
        GameObject[] NodeOrder;


        foreach (GameObject Node in Nodes)
        {
                UncheckedNodes.Add(Node);
        }

        Start.GetComponent<NodeProperties>().cost = 0;

        while (UncheckedNodes.Count > 0)
        {

            GameObject current = UncheckedNodes[0];

            UncheckedNodes.Remove(current);
        }


        return Nodes;
    }
    
}
