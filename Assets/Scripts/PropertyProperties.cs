using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyProperties : MonoBehaviour {
    public float Price;
    public float spawnRate;
    public float spawnAmount;
    public GameObject Property;
    public GameObject CoinSpawnerObject;
    private bool runRentGen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Purchased()
    {
        if (runRentGen != true)
        {
            runRentGen = true;
            StartCoroutine(RentGeneration());
        }
    }


    private IEnumerator RentGeneration()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(10.0f);

            Debug.Log(this.name + " attempted to spawn coins");
            CoinSpawnerObject.GetComponent<CoinSpawner>().CoinSpawn(transform.position, Property);

            //spawn coins

        }
    }
}
