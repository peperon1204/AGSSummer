using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalLine : MonoBehaviour
{
    private bool blockGoalIn;

    private float stayTime;

    private float blockStay;

    private bool countSee;

    private int seconds;

    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        blockGoalIn = false;
        countSee = false;
        stayTime = 5;
        blockStay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(stayTime <= 0)
        {
            blockGoalIn = true;
        }

        if(blockStay >= 3)
        {
            countSee = true;
        }
        else
        {
            countSee = false;
        }

        if(!blockGoalIn)
        {
            if(!countSee)
            {
                stayTime = 5;
                timeText.enabled = false;
            }
            else
            {
                timeText.enabled = true;
                stayTime -= Time.deltaTime;
                seconds = (int)stayTime;
                timeText.text = seconds.ToString();
            }
        }
        else
        {
            timeText.text = ("Win");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        blockStay += Time.deltaTime;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        blockStay = 0;
    }

    public bool CountSee
    {
        get{ return countSee; }  //取得用
        private set{ countSee = value; }　//値入力用
    }
}
