using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceBlockMgr : MonoBehaviour
{
    private Rigidbody2D rb2;

    BoxCollider2D[] collider;

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

    private GameObject playerNumber;
    
    private RacePlayerNumber getPlayerNumber;

    public GameObject root;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();

        timerObject = GameObject.Find("TimeObject");
        timerScript = timerObject.GetComponent<Timer>();

        playerNumber = GameObject.Find("GetPlayerNumber");
        getPlayerNumber = playerNumber.GetComponent<RacePlayerNumber>();

        root = transform.root.gameObject;

        if (root == getPlayerNumber.getNumber[0])
        {
            raceCreateObject = GameObject.Find("BlockCreate (1)");
        }
        else if (root == getPlayerNumber.getNumber[1])
        {
            raceCreateObject = GameObject.Find("BlockCreate (2)");
        }
        else if (root == getPlayerNumber.getNumber[2])
        {
            raceCreateObject = GameObject.Find("BlockCreate (3)");
        }
        else if (root == getPlayerNumber.getNumber[3])
        {
            raceCreateObject = GameObject.Find("BlockCreate (4)");
        }

        raceCreateScript = raceCreateObject.GetComponent<RaceCreate>();

        timerCheck = timerScript.TimerCount;

        collider = gameObject.GetComponentsInChildren<BoxCollider2D>();

        for(int i = 0; i < 4; i++)
        {
            collider[i].enabled = false;
        }

        if(timerCheck >= 0)
        {
            start = true;
        }
        else
        {
            if (root == getPlayerNumber.getNumber[0])
            {
                fallBlock = GameObject.Find("FallBlock1");
                goalLineObject = GameObject.Find("GoalLineObject (1)");
            }
            else if (root == getPlayerNumber.getNumber[1])
            {
                fallBlock = GameObject.Find("FallBlock2");
                goalLineObject = GameObject.Find("GoalLineObject (2)");
            }
            else if (root == getPlayerNumber.getNumber[2])
            {
                fallBlock = GameObject.Find("FallBlock3");
                goalLineObject = GameObject.Find("GoalLineObject (3)");
            }
            else if (root == getPlayerNumber.getNumber[3])
            {
                fallBlock = GameObject.Find("FallBlock4");
                goalLineObject = GameObject.Find("GoalLineObject (4)");
            }

            raceBlockMgr = fallBlock.GetComponent<RaceBlockMgr>();

            goalLine =  goalLineObject.GetComponent<GoalLine>();

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
                for(int i = 0; i < 4; i++)
                {
                    collider[i].enabled = true;
                }
                raceFall.enabled = true;
                raceCtrl.enabled = true;
                raceCreateScript.Create();
                start = false;
                
                if (root == getPlayerNumber.getNumber[0])
                {
                    gameObject.name = "FallBlock1";
                }
                else if (root == getPlayerNumber.getNumber[1])
                {
                    gameObject.name = "FallBlock2";
                }
                else if (root == getPlayerNumber.getNumber[2])
                {
                    gameObject.name = "FallBlock3";
                }
                else if (root == getPlayerNumber.getNumber[3])
                {
                    gameObject.name = "FallBlock4";
                }
            }
        }

        if(standBy)
        {
            if(!goalLine.CountSee)
            {
                if(raceBlockMgr.blockWaiver)
                {
                    for(int i = 0; i < 4; i++)
                    {
                        collider[i].enabled = true;
                    }
                    raceFall.enabled = true;
                    raceCtrl.enabled = true;
                    raceCreateScript.Create();
                    standBy = false;
                    
                    if (root == getPlayerNumber.getNumber[0])
                    {
                        gameObject.name = "FallBlock1";
                    }
                    else if (root == getPlayerNumber.getNumber[1])
                    {
                        gameObject.name = "FallBlock2";
                    }
                    else if (root == getPlayerNumber.getNumber[2])
                    {
                        gameObject.name = "FallBlock3";
                    }
                    else if (root == getPlayerNumber.getNumber[3])
                    {
                        gameObject.name = "FallBlock4";
                    }
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
        if (root == getPlayerNumber.getNumber[0])
        {
            if (other.gameObject.tag == "1P_Floor" || other.gameObject.tag == "BlockWaiver")
            {
                BlockControl();
            }
        }
        if (root == getPlayerNumber.getNumber[1])
        {
            if (other.gameObject.tag == "2P_Floor" || other.gameObject.tag == "BlockWaiver")
            {
                BlockControl();
            }
        }
        if (root == getPlayerNumber.getNumber[2])
        {
            if (other.gameObject.tag == "3P_Floor" || other.gameObject.tag == "BlockWaiver")
            {
                BlockControl();
            }
        }
        if (root == getPlayerNumber.getNumber[3])
        {
            if (other.gameObject.tag == "4P_Floor" || other.gameObject.tag == "BlockWaiver")
            {
                BlockControl();
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

    public void BlockControl()
    {
        if(!blockWaiver)
        {
            raceFall.enabled = false;
            raceCtrl.enabled = false;
            gameObject.name = "BlockWaiver";
            gameObject.tag = "BlockWaiver";
            blockWaiver = true;
        }
        else
        {
            if(rb2.bodyType == RigidbodyType2D.Kinematic)
            {
                rb2.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
