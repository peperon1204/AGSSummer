using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalFall : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public survivalCtrl BlockCtrl;

    private bool speedFall;

    public float normalSpeed;
    public float highSpeed;

    private bool hitCheck;

    private GameObject createObject;

    private survivalCreate createScript;

    private bool nextBlock;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyの初期設定
        rb2d = GetComponent<Rigidbody2D>();

        rb2d.bodyType = RigidbodyType2D.Dynamic;

        //落下速度
        speedFall = false;

        //衝突判定
        hitCheck = false;

        //次のブロック
        nextBlock = false;

        //ブロック生成
        createObject = GameObject.Find("survivalCreate");
        createScript = createObject.GetComponent<survivalCreate>();

    }

    // Update is called once per frame
    void Update()
    {
        if (nextBlock)
        {
            createScript.Create();
            nextBlock = true;
        }
        //if (nextBlock)
        //{
        //    rb2d.bodyType = RigidbodyType2D.Static;
        //    if (Input.GetKeyDown(KeyCode.T))
        //    {
        //        nextBlock = false;
        //        rb2d.bodyType = RigidbodyType2D.Dynamic;

        //        //新しくブロックをつくります
        //        createScript.Create();

        //        //transform.Translate(0.0f, 0.0f, 0.0f);
        //    }
        //}
        //else
        {    //床と他のブロックらにぶつかってなかったら落下するよ
            if (!hitCheck)
            {
                //落下するときは真っ直ぐ落ちます
                rb2d.velocity = Vector2.zero;

                if (!speedFall)
                {
                    //通常落下する
                    transform.Translate(0.0f, -normalSpeed, 0.0f);

                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        //落下速度を高速へ変更
                        speedFall = true;
                    }
                }
                else
                {
                    //高速落下する
                    transform.Translate(0.0f, -highSpeed, 0.0f);

                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        //落下速度を通常速度へ変更
                        speedFall = false;
                    }
                }
            }
            else
            {
                if (rb2d.IsSleeping())
                {
                    rb2d.bodyType = RigidbodyType2D.Kinematic;
                }
            }
        }
        Debug.Log(nextBlock);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //if (!nextBlock)
        {
            if (!hitCheck)
            {
                if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Block")
                {
                    //ぶつかったら落下をやめる
                    hitCheck = true;
                    nextBlock = true;
                }
            }
            else
            {
                if (rb2d.bodyType == RigidbodyType2D.Kinematic && other.gameObject.tag == "Block")
                {
                    rb2d.bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }

        if (other.gameObject.tag == "Bottom")
        {
            Destroy(gameObject);
        }
    }
}
