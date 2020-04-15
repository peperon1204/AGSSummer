using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockCtrl : MonoBehaviour
{
    private Transform child;

    private bool ctrlWaiver;

    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        //回転する中心軸を取得
        child = transform.Find("RotationCenter");

        //ブロック操作が効く状態
        ctrlWaiver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ctrlWaiver)
        {
            timeElapsed += Time.deltaTime;

            //スペースまたは時間経過で落下開始
            if (Input.GetKeyDown(KeyCode.Space) || timeElapsed >= 5)
            {
                //落下したら移動と回転ができなくなるよ
                ctrlWaiver = true;

                timeElapsed = 0;
            }

            //左右移動
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.Translate(0.16f, 0.0f, 0.0f);
            }

            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.Translate(-0.16f, 0.0f, 0.0f);
            }

            //子オブジェクト（中心軸）のRotationを回転させる
            if (Input.GetKeyDown(KeyCode.Z))
            {
               child.Rotate(0.0f, 0.0f, 90.0f);
            }
        }
    }
}
