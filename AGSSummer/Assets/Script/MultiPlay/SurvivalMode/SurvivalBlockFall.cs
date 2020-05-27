using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalBlockFall : MonoBehaviour
{
    private Rigidbody2D rb2;

    private bool speedFall;

    public float normalSpeed;

    public float highSpeed;

    private GameObject playerNumber;
    private GetPlayerNumber getPlayerNumber;

    public GameObject root; //一番上の親を取得する

    public GameObject createEffect;     //ブロック生成時のエフェクト

    private float effectCnt;
    public float effectCntMax;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyの初期設定
        rb2 = GetComponent<Rigidbody2D>();

        rb2.bodyType = RigidbodyType2D.Dynamic;

        Instantiate(createEffect, new Vector3(this.gameObject.transform.position.x + 1.5f, this.gameObject.transform.position.y + 2.0f, 0.0f), Quaternion.identity); //エフェクト生成


        playerNumber = GameObject.Find("GetPlayerNumber");
        getPlayerNumber = playerNumber.GetComponent<GetPlayerNumber>();


        root = transform.root.gameObject;

        if (root == getPlayerNumber.getNumber[0])
        {
            transform.parent = root.transform;
        }
        else if (root == getPlayerNumber.getNumber[1])
        {
            transform.parent = root.transform;
        }
        else if (root == getPlayerNumber.getNumber[2])
        {
            transform.parent = root.transform;
        }
        else if (root == getPlayerNumber.getNumber[3])
        {
            transform.parent = root.transform;
        }
        //transform.Translate(1.5f, 3.0f, 0.0f);

        //落下速度
        speedFall = false;

        Invoke("MovePosition", 0.7f);

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
        transform.Translate(1.5f, 2.0f, 0.0f);
    }
}
