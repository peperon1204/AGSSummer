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

        raceCreateObject = GameObject.Find("BlockCreator");
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
                gameObject.name = "FallBlock";
            }
        }

        if(standBy)
        {
            if(raceBlockMgr.blockWaiver)
            {
                raceCreateScript.Create();
                standBy = false;
                raceFall.enabled = true;
                raceCtrl.enabled = true;
                gameObject.name = "FallBlock";
            }
        }

        if(blockWaiver)
        {
            if(rb2.IsSleeping())
            {
                rb2.bodyType = RigidbodyType2D.Kinematic;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Block")
        {
            if(!blockWaiver)
            {
                gameObject.name = "BlockWaiver";
                raceFall.enabled = false;
                raceCtrl.enabled = false;
                blockWaiver = true;
            }

            if(rb2.bodyType == RigidbodyType2D.Kinematic)
            {
                StartCoroutine("NextFrameBodyType");
            }
        }

        //下に落ちると削除
        if (other.gameObject.tag == "Bottom")
        {
            if(!blockWaiver)
            {
                gameObject.name = "BlockWaiver";
                raceFall.enabled = false;
                raceCtrl.enabled = false;
                blockWaiver = true;
            }

            Destroy(gameObject);
        }
    }

    IEnumerator NextFrameBodyType()
    {
        yield return null;

        rb2.bodyType = RigidbodyType2D.Dynamic;
    }

}
