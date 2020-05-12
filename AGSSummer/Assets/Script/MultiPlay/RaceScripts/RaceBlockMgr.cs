using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceBlockMgr : MonoBehaviour
{
    /*private Rigidbody2D rb2;
    public RaceBlockNext raceBlockNext;*/

    public RaceFall raceFall;

    public RaceCtrl raceCtrl;

    private GameObject timerObject;

    private Timer timerScript;

    private float timerCheck; 

    private bool start;
    
    private GameObject raceCreateObject;
    private RaceCreate raceCreateScript;

    private bool blockWaiver;

    private bool standBy;

    // Start is called before the first frame update
    void Start()
    {
        timerObject = GameObject.Find("TimeObject");
        timerScript = timerObject.GetComponent<Timer>();

        timerCheck = timerScript.TimerCount;

        //ブロック生成
        raceCreateObject = GameObject.Find("RaceCreateBlock");
        raceCreateScript = raceCreateObject.GetComponent<RaceCreate>();

        if(timerCheck >= 0)
        {
            start = true;
        }
        else
        {
            standBy = true;
            start = false;
        }

        blockWaiver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(start)
        {
            timerCheck -= Time.deltaTime;

            if(timerCheck <= 0)
            {
                raceFall.enabled = true;
                raceCtrl.enabled = true;
                raceCreateScript.Create();
                start = false;
            }
        }

        ///Debug.Log (start);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Block")
        {
            if(!blockWaiver)
            {
                raceFall.enabled = false;
                raceCtrl.enabled = false;
                raceCreateScript.Create();
                blockWaiver = true;
            }

            if(standBy)
            {
                raceFall.enabled = true;
                raceCtrl.enabled = true;
                standBy = false;
            }
        }

        //下に落ちると削除
        if (other.gameObject.tag == "Bottom")
        {
            Destroy(gameObject);
        }
    }
}
