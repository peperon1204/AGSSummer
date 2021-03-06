﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMgr : MonoBehaviour
{
    private Rigidbody2D rb2;


    public BlockFall fall;
    public BlockControl ctrl;

    private GameObject timerObject;
    private SingleTimer timerScript;

    private GameObject fallBlock;
    private BlockMgr blockMgr;

    private GameObject createObject;
    private SingleCreateBlock createScript;

    private float timerCheck;

    private bool start;

    private bool standBy;

    private bool blockWaiver;

    private GameObject countdownObject;
    private TimerControl countdownScript;

    public GameObject blockEffect;      //ブロック破壊時のエフェクト

    public AudioClip blockSe1;
    public AudioClip blockSe2;
    AudioSource audioSource;


    //private Transform chilledObject;

    //private Transform child;

    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();

        rb2 = GetComponent<Rigidbody2D>();

        fall.enabled = false;
        ctrl.enabled = false;

        timerObject = GameObject.Find("SingleTimer");
        timerScript = timerObject.GetComponent<SingleTimer>();


        countdownObject = GameObject.Find("Countdown");
        countdownScript = countdownObject.GetComponent<TimerControl>();

        createObject = GameObject.Find("SingleCreateBlock");


        createScript = createObject.GetComponent<SingleCreateBlock>();

        timerCheck = timerScript.TimerCount;

        if (timerCheck >= 0)
        {
            start = true;
        }
        else
        {

            fallBlock = GameObject.Find("FallBlock");


            blockMgr = fallBlock.GetComponent<BlockMgr>();



            standBy = true;
            start = false;
        }

        blockWaiver = false;

        //chilledObject = transform.FindChild("RotationCenter");

        //foreach (Transform child in chilledObject)
        //{
        //    Debug.Log(child.name);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownScript.totalTime > 0)
        {
            if (start)
            {
                timerCheck -= Time.deltaTime;

                if (timerCheck <= 0)
                {
                    fall.enabled = true;
                    start = false;
                    Invoke("CreateScript", 0.8f);

                    audioSource.PlayOneShot(blockSe2);


                    gameObject.name = "FallBlock";

                }
            }

            if (standBy)
            {
                if (blockMgr.blockWaiver)
                {

                    fall.enabled = true;
                    Invoke("CreateScript", 0.8f);
                    
                    standBy = false;

                    audioSource.PlayOneShot(blockSe2);

                    gameObject.name = "FallBlock";

                }

            }


            if (blockWaiver)
            {
                if (rb2.IsSleeping())
                {
                    StartCoroutine("NextFrameBlockBody");
                }
            }
        }
        else if(this.gameObject.name == "FallBlock")
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "BlockWaiver")
        {
            BlockControl();
        }
        
        //下に落ちると削除
        if (other.gameObject.tag == "Bottom")
        {
            if (!blockWaiver)
            {
                blockWaiver = true;
            }
            Destroy(gameObject);


            Instantiate(blockEffect, this.transform.position, Quaternion.identity); //エフェクト生成
        }
    }

    IEnumerator NextFrameBlockBody()
    {
        yield return null;

        rb2.bodyType = RigidbodyType2D.Kinematic;
    }

    public void BlockControl()
    {
        if (!blockWaiver)
        {
            audioSource.PlayOneShot(blockSe1);

            fall.enabled = false;
            ctrl.enabled = false;
            gameObject.name = "BlockWaiver";
            gameObject.tag = "BlockWaiver";
            blockWaiver = true;

        }
        else
        {
            if (rb2.bodyType == RigidbodyType2D.Kinematic)
            {
                rb2.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }

    public void CreateScript()
    {
        createScript.Create();
        ctrl.enabled = true;

    }

   
}
