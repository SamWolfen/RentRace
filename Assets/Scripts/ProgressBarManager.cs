using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarManager : MonoBehaviour
{

    public GameObject ProgressBar;
    public GameObject ProgressBarGreen;
    public GameObject ProgressBarGrey;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public IEnumerator ProgressBarActive(GameObject caller, float reqProgress)
    {

        //progress bar setup
        bool loop = true;
        float progress = 0;
        float progressBar = 0;
        float progressModifier = 200;
        float distanceX = ProgressBarGreen.transform.localPosition.x - ProgressBarGrey.transform.localPosition.x;
        Vector3 initialPosGreen = ProgressBarGreen.transform.localPosition;
        ProgressBar.SetActive(true);
        ProgressBarGreen.transform.localScale = new Vector3(0.1f, ProgressBarGreen.transform.localScale.y);
        var callerVars = caller.GetComponent<ScoreManagerAndInteraction>();



        //create loop to start progress
        while (loop == true)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            if (callerVars.Interacting == true)
            {

                //action
                progress = progress + Time.deltaTime * progressModifier;
                progressModifier++;
                progressBar = progress / reqProgress;
                Debug.Log(progressBar * 100);

                ProgressBarGreen.transform.localScale = new Vector3(progressBar * ProgressBarGrey.transform.localScale.x, ProgressBarGreen.transform.localScale.y);
                ProgressBarGreen.transform.localPosition = new Vector3(initialPosGreen.x - (distanceX * progressBar), ProgressBarGreen.transform.localPosition.y);

                //test if action is complete
                if (progress >= reqProgress)
                {
                    //complete action, reset loading bar
                    ProgressBar.SetActive(false);
                    ProgressBarGreen.transform.localPosition = initialPosGreen;
                    loop = false;
                    
                };

            }
            else
            {
                //resets if interaction is canceled
                ProgressBar.SetActive(false);
                ProgressBarGreen.transform.localPosition = initialPosGreen;
                loop = false;
            }


        }
    }
}
