using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeechToggle : MonoBehaviour
{
    
    public GameObject SpeechBubble;
    public GameObject Electricity;
    public GameObject Water;

    public void ToggleUtil(PropertyProperties.DamageType damageType)
    {
        SpeechBubble.SetActive(true);

        switch (damageType)
        {
            case PropertyProperties.DamageType.Water:
                Water.SetActive(true);
                Electricity.SetActive(false);
                break;

            case PropertyProperties.DamageType.Electricity:
                Water.SetActive(false);
                Electricity.SetActive(true);
                break;
            case PropertyProperties.DamageType.None:
                SpeechBubble.SetActive(false);
                break;
        }
    }
}
