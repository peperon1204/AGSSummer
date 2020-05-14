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
                Physics2D.gravity = new Vector3(0,0,0);
            }
        }

        if(standBy)
        {
            if(raceBlockMgr.blockWaiver)
            {
                raceFall.enabled = true;
                raceCtrl.enabled = true;
                raceCreateScript.Create();
                standBy = false;
                gameObject.name = "FallBlock";
                Physics2D.gravity = new Vector3(0,0,0);
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
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "BlockWaiver")
        {
            if(!blockWaiver)
            {
                raceFall.enabled = false;
                raceCtrl.enabled = false;
                gameObject.name = "BlockWaiver";
                gameObject.tag = "BlockWaiver";
                blockWaiver = true;

                StartCoroutine("NextFrameGravity");
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

    IEnumerator NextFrameGravity()
    {
        yield return null;

        Physics2D.gravity = new Vector3(0,-10,0);
    }
}
