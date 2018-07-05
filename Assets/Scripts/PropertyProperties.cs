using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyProperties : MonoBehaviour
{
    public float Price;
    public float spawnRate;
    public float spawnAmount;
    public GameObject Property;
    public GameObject CoinSpawnerObject;
    public GameObject SpeechBubble;
    private bool runRentGen;

    #region //damage variables
    public enum DamageType
    {
        Water,
        Electricity,
        None
    }
    public float Damage;
    public float DamageScale;
    public DamageType damageType;
    public int damageChance;
    private bool damageCoroutineRunning = false;

    #endregion 



    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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


            if (damageType == DamageType.None)
            {
                if (Random.Range(1, damageChance) == 1)
                {

                    //if damage is 0 initially then things screw up
                    Damage = 1;


                    if (Random.Range(1, 2) == 1)
                    {
                        damageType = DamageType.Water;

                    }
                    else
                    {
                        damageType = DamageType.Electricity;
                    }

                    //tag = "Damaged";
                }

                SpeechBubble.GetComponent<SpeechToggle>().ToggleUtil(damageType);

                if(!damageCoroutineRunning)
                {
                    StartCoroutine(DamageCalcAndDisplay());
                }

            }

            if (damageType == DamageType.None)
            {
                Debug.Log(this.name + " attempted to spawn coins");
                CoinSpawnerObject.GetComponent<CoinSpawner>().CoinSpawn(transform.position, Property);

            }
            //spawn coins


            yield return new WaitForSecondsRealtime(10.0f);
        }
    }

    private IEnumerator DamageCalcAndDisplay()
    {
        damageCoroutineRunning = true;
        while (damageType != DamageType.None)
        {
            if (Damage <= 100)
            {
                Damage += DamageScale;
            }

            yield return new WaitForSecondsRealtime(2);
        }


        Damage = 0;
        SpeechBubble.GetComponent<SpeechToggle>().ToggleUtil(damageType);
        damageCoroutineRunning = false;

    }
}
