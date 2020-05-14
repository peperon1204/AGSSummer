using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalLine : MonoBehaviour
{
    private bool goalIn;

    private float stayTime;

    private bool countSee;

    private int seconds;

    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        goalIn = false;
        countSee = false;
        stayTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(stayTime <= 0)
        {
            goalIn = true;
        }

        if(countSee)
        {
            timeText.enabled = true;
            stayTime -= Time.deltaTime;
            seconds = (int)stayTime;
            timeText.text = seconds.ToString();
        }
        else
        {
            stayTime = 5;
            timeText.enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "BlockWaiver")
        {
            countSee = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        countSee = false;
    }
}
