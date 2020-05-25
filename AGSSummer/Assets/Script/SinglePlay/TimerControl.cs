using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerControl : MonoBehaviour
{
    public Text timerText;

    public float totalTime;
    private int seconds;

    private GameObject timerObject;
    private SingleTimer singleTimerScript;

    // Use this for initialization
    void Start()
    {
        timerObject = GameObject.Find("SingleTimer");
        singleTimerScript = timerObject.GetComponent<SingleTimer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (singleTimerScript.timerCount < 0)
        {
            totalTime -= Time.deltaTime;
            seconds = (int)totalTime;
            timerText.text = "残りの時間" + seconds.ToString();
        }

        if(totalTime < 0)
        {
            totalTime = 0;
        }
    }
}
