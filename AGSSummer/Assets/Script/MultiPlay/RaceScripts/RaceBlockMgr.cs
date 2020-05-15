using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceBlockMgr : MonoBehaviour
{
    private Rigidbody2D rb2;

    public RaceFall raceFall;

    public RaceCtrl raceCtrl;

    private GameObject timerObject;

    private Timer timerScript;

    private GameObject fallBlock;

    private RaceBlockMgr raceBlockMgr;

    private GameObject raceCreateObject;

    private RaceCreate raceCreateScript;

    private GameObject goalLineObject;

    private GoalLine goalLine;

    private float timerCheck; 

    private bool start;
    
    private bool standBy;

    private bool blockWaiver;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();

        timerObject = GameObject.Find("TimeObject");
        timerScript = timerObject.GetComponent<Timer>();

        raceCreateObject = GameObject.Find("BlockCreate");
        raceCreateScript = raceCreateObject.GetComponent<RaceCreate>();

        timerCheck = timerScript.TimerCount;

        if(timerCheck >= 0)
        {
            start = true;
        }
        else
        {
            fallBlock = GameObject.Find("FallBlock");
            raceBlockMgr = fallBlock.GetComponent<RaceBlockMgr>();

            goalLineObject = GameObject.Find("GoalLineObject");
            goalLine =  goalLineObject.GetComponent<GoalLine>();

            standBy = true;
            start = false;
        }

        blockWaiver = false;
    }

    /*"やらなきゃいけないこと"
    "落ちたブロックがゴールラインに触れているかを取得"
    
    if"触れていた場合"
    {    
        "Next表示のブロックの一時停止"
        "触れている間タイマーをセット"

        if"タイマーが０になったら"
        {
            gameset;
        }
    }
    else "0になる前に触れるのをやめたら"
    {
        "Next表示のブロックを落とす"
        "タイマーをリセット"
    }
    */
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
                gameObject.name = "FallBlock";
            }
        }

        if(standBy)
        {
            if(!goalLine.CountSee)
            {
                if(raceBlockMgr.blockWaiver)
                {
                    raceFall.enabled = true;
                    raceCtrl.enabled = true;
                    raceCreateScript.Create();
                    standBy = false;
                    gameObject.name = "FallBlock";
                }
            }
        }
        

        if(blockWaiver)
        {
            if(rb2.IsSleeping())
            {
                StartCoroutine("NextFrameBlockBody");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(!blockWaiver)
        {
            if (other.gameObject.tag == "Floor" || other.gameObject.tag == "BlockWaiver")
            {
                raceFall.enabled = false;
                raceCtrl.enabled = false;
                gameObject.name = "BlockWaiver";
                gameObject.tag = "BlockWaiver";
                blockWaiver = true;
            }
        }
        else
        {
            if (other.gameObject.tag == "BlockWaiver")
            {
                if(rb2.bodyType == RigidbodyType2D.Kinematic)
                {
                    rb2.bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }

        //下に落ちると削除
        if (other.gameObject.tag == "Bottom")
        {
            if(!blockWaiver)
            {
                blockWaiver = true;
            }

            Destroy(gameObject);
        }
    }

    IEnumerator NextFrameBlockBody()
    {
        yield return null;

        rb2.bodyType = RigidbodyType2D.Kinematic;
    }
}
