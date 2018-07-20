using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour {
    public GameObject Agent;
    public float Price;
    public int runs = 0;
    int maxRuns = 3;
    


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HireAgent()
    {
        Agent.SetActive(true);
        Agent.GetComponent<PathFinding>().Activated();
        Agent.transform.position = transform.position;
        tag = "HiredAgency";
        runs = 0;
        
        Agent.GetComponent<RealEstateAgent>().isActive = true;
    }

    public void AgentFinished()
    {

        if (runs >= maxRuns)
        {
            
            Agent.GetComponent<RealEstateAgent>().isActive = false;
            tag = "Agency";
        }



    }


}
