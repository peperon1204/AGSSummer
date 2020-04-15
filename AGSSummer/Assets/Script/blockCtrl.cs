using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockCtrl : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    private Transform child;

    private bool ctrlWaiver;

    private float timeElapsed;

    private float mouse_move_x;

    private float mouse_sensitivity;

    private bool sensitivity_switch;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        //生成時に落下しない処理
        rigidbody2d.bodyType = RigidbodyType2D.Kinematic;

        //回転する中心軸を取得
        child = transform.Find("RotationCenter");

        //ブロック操作が効く状態
        ctrlWaiver = false;

        sensitivity_switch = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (sensitivity_switch)
        {
            if (Input.GetMouseButtonDown(1))
            {
                sensitivity_switch = false;
            }

            mouse_sensitivity = 0.2f;
        }
        else
        {
            if (Input.GetMouseButtonDown(1))
            {
                sensitivity_switch = true;
            }

            mouse_sensitivity = 0.4f;
        }

        mouse_move_x = Input.GetAxis("Mouse X") * mouse_sensitivity;

        if (!ctrlWaiver)
        {
            timeElapsed += Time.deltaTime;

            //スペースまたは時間経過で落下開始
            if (Input.GetKeyDown(KeyCode.Space) || timeElapsed >= 5)
            {
                //落下する
                rigidbody2d.bodyType = RigidbodyType2D.Dynamic;

                //落下したら移動と回転ができなくなるよ
                ctrlWaiver = true;

                timeElapsed = 0;
            }

            //左右移動
            
            transform.Translate(mouse_move_x, 0.0f, 0.0f);
            
            //子オブジェクト（中心軸）のRotationを回転させる
            if (Input.GetMouseButtonDown(0))
            {
               child.Rotate(0.0f, 0.0f, 90.0f);
            }
        }
    }
}
