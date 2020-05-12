using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer;

    private int seconds;

    public Text timeText;
    
    private bool start;
    //public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 0)
        {
            timer -= Time.deltaTime;
            seconds = (int)timer;
            timeText.text = seconds.ToString();
        }
        else
        {
            timeText.enabled = false;
            start = false;
        }
    }

    public bool StartCheck()
    {
        return start;
    } 

    public float TimerCheck()
    {
        return timer;
    }
}
