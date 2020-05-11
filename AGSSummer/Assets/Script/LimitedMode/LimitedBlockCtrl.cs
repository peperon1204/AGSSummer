using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedBlockCtrl : MonoBehaviour
{
    private Transform child;

    private bool highSpeed;
    private bool touch;

    // Start is called before the first frame update
    void Start()
    {
        //回転する中心軸を取得
        child = transform.Find("RotationCenter");

        //true:高速落下     false:通常落下
        highSpeed = false;

        //true:触れている    false:触れていない
        touch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!highSpeed)
        {
            //スペースで高速落下開始
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //高速落下したら移動と回転ができなくなるよ
                highSpeed = true;
            }

            //左右移動
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.Translate(0.16f, 0.0f, 0.0f);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.Translate(-0.16f, 0.0f, 0.0f);
            }

            //子オブジェクト（中心軸）のRotationを回転させる
            if (Input.GetKeyDown(KeyCode.Z))
            {
                child.Rotate(0.0f, 0.0f, 90.0f);
            }
        }
        else
        {
            if (!touch)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    //高速落下していた場合高速落下解除
                    highSpeed = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Block")
        {
            //床や他のブロックにぶつかったら移動と回転させない
            highSpeed = true;
            touch = true;
        }
    }
}
