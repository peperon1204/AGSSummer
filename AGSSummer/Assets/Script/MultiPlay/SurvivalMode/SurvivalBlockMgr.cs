using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalBlockMgr : MonoBehaviour
{
    private Rigidbody2D rb2;

    public SurvivalBlockFall survivalFall;
    public SurvivalBlockCtrl survivalCtrl;

    private GameObject timerObject;
    private SurvivalTimer timerScript;

    private GameObject fallBlock;

    private SurvivalBlockMgr survivalBlockMgr;
    private GameObject survivalCreateObject;
    private SurvivalCreateBlock survivalCreateScript;

    private float timerCheck;

    private bool start;
    private bool standBy;
    private bool blockWaiver;

    private GameObject playerNumber;
    private GetPlayerNumber getPlayerNumber;

    private GameObject playerLife;
    private Life lifeScript;

    public GameObject root; //一番上の親を取得する

    private GameObject loseProcessObject;
    private SurvivalResult loseScript;

    private GameObject gameResult;
    private ResultProcess resultScript;

    private bool fixBlock; //true:ブロックの固定

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();

        fixBlock = false;

        timerObject = GameObject.Find("SurvivalTime");
        timerScript = timerObject.GetComponent<SurvivalTimer>();

        // survivalCreateObject = GameObject.Find("CreateBlock");
        //survivalCreateScript = survivalCreateObject.GetComponent<SurvivalCreateBlock>();

        playerNumber = GameObject.Find("GetPlayerNumber");
        getPlayerNumber = playerNumber.GetComponent<GetPlayerNumber>();

        //playerLife = GameObject.Find("PlayerLife");
        gameResult = GameObject.Find("ResultManager");
        resultScript = gameResult.GetComponent<ResultProcess>();


        root = transform.root.gameObject;

        if (root == getPlayerNumber.getNumber[0])
        {
            survivalCreateObject = GameObject.Find("CreateBlock (1)");
            playerLife = GameObject.Find("Life (1)");
            loseProcessObject = GameObject.Find("Player1");
        }
        else if (root == getPlayerNumber.getNumber[1])
        {
            survivalCreateObject = GameObject.Find("CreateBlock (2)");
            playerLife = GameObject.Find("Life (2)");
            loseProcessObject = GameObject.Find("Player2");
        }
        else if (root == getPlayerNumber.getNumber[2])
        {
            survivalCreateObject = GameObject.Find("CreateBlock (3)");
            playerLife = GameObject.Find("Life (3)");
            loseProcessObject = GameObject.Find("Player3");
        }
        else if (root == getPlayerNumber.getNumber[3])
        {
            survivalCreateObject = GameObject.Find("CreateBlock (4)");
            playerLife = GameObject.Find("Life (4)");
            loseProcessObject = GameObject.Find("Player4");
        }

        survivalCreateScript = survivalCreateObject.GetComponent<SurvivalCreateBlock>();
        lifeScript = playerLife.GetComponent<Life>();


        loseScript = loseProcessObject.GetComponent<SurvivalResult>();

        timerCheck = timerScript.TimerCount;

        survivalFall.enabled = false;
        survivalCtrl.enabled = false;

        if (timerCheck >= 0)
        {
            start = true;
        }
        else
        {

            standBy = true;
            start = false;

            if (root == getPlayerNumber.getNumber[0])
            {
                fallBlock = GameObject.Find("FallBlock1");
            }
            else if (root == getPlayerNumber.getNumber[1])
            {
                fallBlock = GameObject.Find("FallBlock2");
            }
            else if (root == getPlayerNumber.getNumber[2])
            {
                fallBlock = GameObject.Find("FallBlock3");
            }
            else if (root == getPlayerNumber.getNumber[3])
            {
                fallBlock = GameObject.Find("FallBlock4");
            }

            survivalBlockMgr = fallBlock.GetComponent<SurvivalBlockMgr>();

        }

        blockWaiver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!loseScript.loseFlag && !resultScript.winFlag)
        {
            //fixBlock = false;

            if (start)
            {
                timerCheck -= Time.deltaTime;

                if (timerCheck <= 0)
                {
                    survivalFall.enabled = true;
                    survivalCtrl.enabled = true;
                    survivalCreateScript.Create();
                    start = false;
                    // gameObject.name = "FallBlock";
                    Physics2D.gravity = new Vector3(0, 0, 0);
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

            if (standBy)
            {
                if (survivalBlockMgr.blockWaiver)
                {
                    survivalFall.enabled = true;
                    survivalCtrl.enabled = true;
                    survivalCreateScript.Create();
                    standBy = false;
                    //gameObject.name = "FallBlock";
                    Physics2D.gravity = new Vector3(0, 0, 0);

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

                if (blockWaiver)
                {
                    if (rb2.IsSleeping())
                    {
                        rb2.bodyType = RigidbodyType2D.Kinematic;
                    }
                }

                Debug.Log(getPlayerNumber);

                if (root == getPlayerNumber.getNumber[0])
                {
                    survivalCreateObject = GameObject.Find("CreateBlock (1)");
                }
                else if (root == getPlayerNumber.getNumber[1])
                {
                    survivalCreateObject = GameObject.Find("CreateBlock (2)");
                }
                else if (root == getPlayerNumber.getNumber[2])
                {
                    survivalCreateObject = GameObject.Find("CreateBlock (3)");
                }
                else if (root == getPlayerNumber.getNumber[3])
                {
                    survivalCreateObject = GameObject.Find("CreateBlock (4)");
                }
            }
        }
        else
        {
            fixBlock = true;
            if (this.gameObject.name == "FallBlock1")
            {
                Destroy(this.gameObject);
            }
            else if (this.gameObject.name == "FallBlock2")
            {
                Destroy(this.gameObject);
            }
            else if (this.gameObject.name == "FallBlock3")
            {
                Destroy(this.gameObject);
            }
            else if (this.gameObject.name == "FallBlock4")
            {
                Destroy(this.gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            fixBlock = true;
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
            if (!blockWaiver)
            {
                blockWaiver = true;
            }

            lifeScript.LifeLost();
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

        Physics2D.gravity = new Vector3(0, -10, 0);
    }

    public void BlockControl()
    {
        if (!blockWaiver)
        {
            survivalFall.enabled = false;
            survivalCtrl.enabled = false;
            gameObject.name = "BlockWaiver";
            gameObject.tag = "BlockWaiver";
            blockWaiver = true;

            StartCoroutine("NextFrameGravity");
        }



        if (rb2.bodyType == RigidbodyType2D.Kinematic)
        {
            StartCoroutine("NextFrameBodyType");
        }

        if (fixBlock)
        {
            fixBlock = false;
            rb2.bodyType = RigidbodyType2D.Static;
            
        }
    }
}
