using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SurvivalTimer : MonoBehaviour
{
    private float timerCount;

    private int seconds;

    public Text timeText;

    private bool start;

    // Start is called before the first frame update
    void Start()
    {
        timerCount = 5;
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (timerCount >= 0)
            {
                timerCount -= Time.deltaTime;
                seconds = (int)timerCount;
                timeText.text = seconds.ToString();
            }
            else
            {
                timeText.enabled = false;
            }
        }
    }

    public float TimerCount
    {
        get { return timerCount; }  //取得用
        private set { timerCount = value; }　//値入力用
    }
}
