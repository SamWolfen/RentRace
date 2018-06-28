using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarPathingAlgorithm : MonoBehaviour
{
    float f;
    float g;
    float h;
    int n;

    // the following explaination is from https://www.geeksforgeeks.org/a-search-algorithm/
    /*
     * Explanation
    Consider a square grid having many obstacles and we are given a starting cell and a target cell. We want to reach the target cell (if possible) from the starting cell as quickly as possible. Here A* Search Algorithm comes to the rescue.
    
    What A* Search Algorithm does is that at each step it picks the node according to a value-‘f’ which is a parameter equal to the sum of two other parameters – ‘g’ and ‘h’. At each step it picks the node/cell having the lowest ‘f’, and process that node/cell.

    We define ‘g’ and ‘h’ as simply as possible below

    g = the movement cost to move from the starting point to a given square on the grid, following the path generated to get there.
    h = the estimated movement cost to move from that given square on the grid to the final destination. This is often referred to as the heuristic, 
    which is nothing but a kind of smart guess. We really don’t know the actual distance until we find the path,
    because all sorts of things can be in the way (walls, water, etc.).
    There can be many ways to calculate this ‘h’ which are discussed in the later sections.
      
     */


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
