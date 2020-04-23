﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fallBlock : MonoBehaviour
{ 
    private Rigidbody2D rb2;

    public blockCtrl BlockCtrl;

    private bool speedFall;

    public float normalSpeed;
    public float highSpeed;

    private bool hitCheck;
    
    private GameObject createObject;

    private createBlock createScript;
    
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyの初期設定
        rb2 = GetComponent<Rigidbody2D>();

        rb2.bodyType = RigidbodyType2D.Dynamic;

        //落下速度
        speedFall = false;

        //衝突判定
        hitCheck = false;

        //ブロック生成
        createObject = GameObject.Find("CreateBlock");
        createScript = createObject.GetComponent<createBlock>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hitCheck);
        //床と他のブロックらにぶつかってなかったら落下するよ
        if (!hitCheck)
        {
            //落下するときは真っ直ぐ落ちます
            rb2.velocity = Vector2.zero;

            if (!speedFall)
            {
                //低速落下する
                transform.Translate(0.0f, -normalSpeed, 0.0f);
                
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    //落下速度を変えます
                    speedFall = true;
                }
            }
            else
            {
                //高速落下する
                transform.Translate(0.0f, -highSpeed, 0.0f);
            }
        }
        else
        {
            if (rb2.IsSleeping())
            {
                rb2.bodyType = RigidbodyType2D.Kinematic;
            }
        }
    }
    

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!hitCheck)
        {
            if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Block")
            {
                //ぶつかったので落下をやめます
                hitCheck = true;

                //新しくブロックをつくります
                createScript.Create();
            }
        }

        if(other.gameObject.tag == "Bottom")
        {
            Destroy(gameObject);
        }
    }
}