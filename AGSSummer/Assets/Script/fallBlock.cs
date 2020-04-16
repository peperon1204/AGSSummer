using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallBlock : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    public blockCtrl BlockCtrl;
    
    private bool speedFall;

    private bool hitWithAnother;
    
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
        hitWithAnother = false;

        //ブロック生成
        createObject = GameObject.Find("CreateBlock");
        createScript = createObject.GetComponent<createBlock>();
    }

    // Update is called once per frame
    void Update()
    {
        //床と他のブロックらにぶつかってなかったら落下するよ
        if (!hitWithAnother)
        {
            //落下するときは真っ直ぐ落ちます
            rigidbody2d.velocity = Vector2.zero;

            if (!speedFall)
            {
                //低速落下する
                transform.Translate(0.0f, -0.01f, 0.0f);
                
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //落下速度を変えます
                    speedFall = true;
                }
            }
            else
            {
                //高速落下する
                transform.Translate(0.0f, -0.16f, 0.0f);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!hitWithAnother)
        {
            if (other.gameObject.tag == "floor" || other.gameObject.tag == "Block")
            {
                //ぶつかったので落下をやめます
                hitWithAnother = true;

                //新しくブロックをつくります
                createScript.Create();
            }
        }
    }
}
