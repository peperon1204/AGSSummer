﻿using System.Collections;
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

    private RaceBlockMgr myBlockMgr;

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

    private bool fixedBlock;

    private GameObject FixedObj;

    private FixedBlock fixedPermit;

    public GameObject blockEffect;

    private GameObject GrandchildObj1;

    private GameObject GrandchildObj2;

    private GameObject GrandchildObj3;

    private GameObject GrandchildObj4;

    private SpriteRenderer spriteRenderer1;

    private SpriteRenderer spriteRenderer2;

    private SpriteRenderer spriteRenderer3;

    private SpriteRenderer spriteRenderer4;

    public AudioClip blockSe1;

    public AudioClip blockSe2;

    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        GrandchildObj1 = transform.Find("RotationCenter/sourceBlock").gameObject;
        GrandchildObj2 = transform.Find("RotationCenter/sourceBlock (1)").gameObject;
        GrandchildObj3 = transform.Find("RotationCenter/sourceBlock (2)").gameObject;
        GrandchildObj4 = transform.Find("RotationCenter/sourceBlock (3)").gameObject;

        spriteRenderer1 = GrandchildObj1.GetComponent<SpriteRenderer>();
        spriteRenderer2 = GrandchildObj2.GetComponent<SpriteRenderer>();
        spriteRenderer3 = GrandchildObj3.GetComponent<SpriteRenderer>();
        spriteRenderer4 = GrandchildObj4.GetComponent<SpriteRenderer>();

        audioSource = GetComponent<AudioSource>();

        rb2 = GetComponent<Rigidbody2D>();

        collider = gameObject.GetComponentsInChildren<BoxCollider2D>();

        for(int i = 0; i < 4; i++)
        {
            collider[i].enabled = false;
        }

        timerObject = GameObject.Find("TimeObject");
        timerScript = timerObject.GetComponent<Timer>();

        timerCheck = timerScript.TimerCount;

        playerNumber = GameObject.Find("GetPlayerNumber");
        getPlayerNumber = playerNumber.GetComponent<RacePlayerNumber>();

        root = transform.root.gameObject;

        if (root == getPlayerNumber.getNumber[0])
        {
            raceCreateObject = GameObject.Find("BlockCreate (1)");
            FixedObj = GameObject.Find("FixedObj (1)");
        }
        else if (root == getPlayerNumber.getNumber[1])
        {
            raceCreateObject = GameObject.Find("BlockCreate (2)");
            FixedObj = GameObject.Find("FixedObj (2)");
        }
        else if (root == getPlayerNumber.getNumber[2])
        {
            raceCreateObject = GameObject.Find("BlockCreate (3)");
            FixedObj = GameObject.Find("FixedObj (3)");
        }
        else if (root == getPlayerNumber.getNumber[3])
        {
            raceCreateObject = GameObject.Find("BlockCreate (4)");
            FixedObj = GameObject.Find("FixedObj (4)");
        }

        raceCreateScript = raceCreateObject.GetComponent<RaceCreate>();

        fixedPermit = FixedObj.GetComponent<FixedBlock>();

        blockWaiver = false;

        fixedBlock = false;

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

            myBlockMgr = gameObject.GetComponent<RaceBlockMgr>();

            goalLine =  goalLineObject.GetComponent<GoalLine>();

            standBy = true;
            start = false;
        }
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

                audioSource.PlayOneShot(blockSe2);
                
                raceFall.enabled = true;
                raceCtrl.enabled = true;
                Invoke("BlockInstance", 0.7f);
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

                    audioSource.PlayOneShot(blockSe2);

                    raceFall.enabled = true;
                    raceCtrl.enabled = true;
                    Invoke("BlockInstance", 0.7f);
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
        else
        {
            if(!blockWaiver)
            {
                if(!fixedPermit.UsedItem)
                {
                    if(fixedPermit.FixedPermit)
                    {
                        if (root == getPlayerNumber.getNumber[0])
                        {
                            if(Input.GetKeyDown(KeyCode.Z))
                            {
                                fixedBlock = true;
                                spriteRenderer1.color = Color.blue;
                                spriteRenderer2.color = Color.blue;
                                spriteRenderer3.color = Color.blue;
                                spriteRenderer4.color = Color.blue;
                            }
                        }
                        else if (root == getPlayerNumber.getNumber[1])
                        {
                            if(Input.GetKeyDown(KeyCode.X))
                            {
                                fixedBlock = true;
                                spriteRenderer1.color = Color.blue;
                                spriteRenderer2.color = Color.blue;
                                spriteRenderer3.color = Color.blue;
                                spriteRenderer4.color = Color.blue;
                            }
                        }
                        else if (root == getPlayerNumber.getNumber[2])
                        {
                            if(Input.GetKeyDown(KeyCode.C))
                            {
                                fixedBlock = true;
                                spriteRenderer1.color = Color.blue;
                                spriteRenderer2.color = Color.blue;
                                spriteRenderer3.color = Color.blue;
                                spriteRenderer4.color = Color.blue;
                            }
                        }
                        else if (root == getPlayerNumber.getNumber[3])
                        {
                            if(Input.GetKeyDown(KeyCode.V))
                            {
                                fixedBlock = true;
                                spriteRenderer1.color = Color.blue;
                                spriteRenderer2.color = Color.blue;
                                spriteRenderer3.color = Color.blue;
                                spriteRenderer4.color = Color.blue;
                            }
                        }
                    }
                }
            }
        } 
        
        if(blockWaiver)
        {
            if(rb2.IsSleeping())
            {
                //StartCoroutine("NextFrameBlockBody");
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
            
            Instantiate(blockEffect, this.transform.position, Quaternion.identity); 
            Destroy(gameObject);
        }
    }

    IEnumerator NextFrameBlockBody()
    {
        yield return null;

        rb2.bodyType = RigidbodyType2D.Kinematic;
    }

    public void BlockInstance()
    {
        raceCreateScript.Create();
    }

    public void BlockControl()
    {
        if(!blockWaiver)
        {
            audioSource.PlayOneShot(blockSe1);
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

        if(fixedBlock)
        {
            Debug.Log("Static");
            rb2.bodyType = RigidbodyType2D.Static;
            myBlockMgr.enabled = false;
        }
    }
}