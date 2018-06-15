using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeechToggle : MonoBehaviour
{
    
    public GameObject SpeechBubble;
    public GameObject Face;
    public GameObject Electricity;
    public GameObject Water;

    public GameObject Coin;
    public GameObject Text;

    public void ToggleUtil(PropertyProperties.DamageType damageType)
    {
        SpeechBubble.SetActive(true);
        Face.SetActive(true);

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
                Face.SetActive(false);
                Water.SetActive(false);
                Electricity.SetActive(false);
                break;
        }
    }

    public void ToggleCantFindCoin(bool trulse)
    {
        SpeechBubble.SetActive(trulse);
        Coin.SetActive(trulse);
        Text.SetActive(trulse);

    }
}
