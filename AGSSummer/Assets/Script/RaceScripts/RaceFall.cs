using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceFall : MonoBehaviour
{
    private Rigidbody2D rb2;

    public RaceCtrl raceCtrl;

    private bool speedFall;

    public float normalSpeed;
    public float highSpeed;

    private bool hitCheck;

    private GameObject raceCreateObject;
    private RaceCreate raceCreateScript;

    public GameObject MyBlock;

    private bool nextBlock;

    private bool nextCreate;

    private bool start;

    private float Timer;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyの初期設定
        rb2 = GetComponent<Rigidbody2D>();

        rb2.bodyType = RigidbodyType2D.Static;

        //落下速度
        speedFall = false;

        //衝突判定
        hitCheck = false;

        //次のブロック
        nextBlock = true;

        //次の移行
        nextCreate = false;

        //
        start = true;

        Timer = 5;

        //ブロック生成
        raceCreateObject = GameObject.Find("RaceCreateBlock");
        raceCreateScript = raceCreateObject.GetComponent<RaceCreate>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(hitCheck);

        if (start)
        {
            Timer -= Time.deltaTime;

            if (Timer <= 0)
            {
                start = false;
                nextCreate = true;
            }
        }

        if (!hitCheck)
        {
            if (nextCreate)
            {
                rb2.bodyType = RigidbodyType2D.Dynamic;

                transform.Translate(3.0f, 3.0f, 0.0f);

                nextCreate = false;

                nextBlock = false;

                raceCreateScript.Create();
            }

            if (!nextBlock)
            {
                raceCtrl.enabled = true;

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
        }
        else
        {
            raceCtrl.enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(!nextBlock)
        {
            if (!hitCheck)
            {
                if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Block")
                {
                    hitCheck = true;
                    nextCreate = true;
                }
            }
            else
            {
                if (rb2.IsSleeping())
                {
                    rb2.bodyType = RigidbodyType2D.Kinematic;

                    if (rb2.bodyType == RigidbodyType2D.Kinematic && other.gameObject.tag == "Block")
                    {
                        rb2.bodyType = RigidbodyType2D.Dynamic;
                    }
                }
            }
        }
        
        //下に落ちると削除
        if (other.gameObject.tag == "Bottom")
        {
            Destroy(gameObject);
        }
    }
}
