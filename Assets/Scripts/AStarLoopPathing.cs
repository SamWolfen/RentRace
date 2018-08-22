using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AStarLoopPathing : MonoBehaviour
{

    public bool pathingBuggy;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(PathUpdate());
    }

    IEnumerator PathUpdate()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            GetComponent<Pathfinding.AILerp>().SearchPath();

            if (pathingBuggy)
            {
                BuggyPathingFix();
            }
        }
    }

    void BuggyPathingFix()
    {
        if (GetComponent<Pathfinding.AILerp>().enabled == false)
        {
            GetComponent<Pathfinding.AILerp>().enabled = true;
        }else
        {
            GetComponent<Pathfinding.AILerp>().enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
