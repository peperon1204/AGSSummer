using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallBlock : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    public blockCtrl BlockCtrl;

    private bool speedFall;

    public float normalSpeed = 0.0f;
    public float highSpeed = 0.0f;

    private bool hitCheck;
    
    private GameObject createObject;

    private createBlock createScript;
    
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyの初期設定
        rigidbody2d = GetComponent<Rigidbody2D>();

        rigidbody2d.bodyType = RigidbodyType2D.Dynamic;

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
        //床と他のブロックらにぶつかってなかったら落下するよ
        if (!hitCheck)
        {
            //落下するときは真っ直ぐ落ちます
            rigidbody2d.velocity = Vector2.zero;

            if (!speedFall)
            {
                //低速落下する
                transform.Translate(0.0f, -0.04f, 0.0f);
                
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //落下速度を変えます
                    speedFall = true;
                }
            }
            else
            {
                //高速落下する
                transform.Translate(0.0f, -0.32f, 0.0f);
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
        Debug.Log("当たり");
    }
}
