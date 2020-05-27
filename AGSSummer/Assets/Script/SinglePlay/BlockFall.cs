using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFall : MonoBehaviour
{
    private Rigidbody2D rb2;

    private bool speedFall;

    public float normalSpeed;

    public float highSpeed;

    public GameObject createEffect;     //ブロック生成時のエフェクト

    private float effectCnt;
    public float effectCntMax;
    // Start is called before the first frame update
    void Start()
    {
        effectCnt = 0.0f;
        //Rigidbodyの初期設定
        rb2 = GetComponent<Rigidbody2D>();

        rb2.bodyType = RigidbodyType2D.Dynamic;



        Instantiate(createEffect, new Vector3(this.gameObject.transform.position.x + 4.0f, this.gameObject.transform.position.y + 2.0f, 0.0f), Quaternion.identity); //エフェクト生成

        Invoke("MovePosition", 0.7f);

        //落下速度
        speedFall = false;
    }

    // Update is called once per frame
    void Update()
    {
        rb2.velocity = Vector2.zero;

        effectCnt++;

        if (effectCnt > effectCntMax)
        {


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
    public void MovePosition()
    {
        transform.Translate(4.0f, 2.0f, 0.0f);
    }
}
