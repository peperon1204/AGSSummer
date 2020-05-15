using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalBlockCtrl : MonoBehaviour
{
    private Transform child;

    private bool ctrlWaiver;

    // Start is called before the first frame update
    void Start()
    {
        //回転する中心軸を取得
        child = transform.Find("RotationCenter");
    }

    // Update is called once per frame
    void Update()
    {
        if (!ctrlWaiver)
        {
            //スペースで高速落下開始
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //高速落下したら移動と回転ができなくなるよ
                ctrlWaiver = true;
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                child.Rotate(0.0f, 0.0f, 90.0f);
            }
        }
    }
}
