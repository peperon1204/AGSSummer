using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceFall : MonoBehaviour
{
    private Rigidbody2D rb2;

    public bool speedFall;

    public float normalSpeed;

    public float highSpeed;

    public GameObject createEffect;     //ブロック生成時のエフェクト

    private float effectCnt;

    public float effectCntMax;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyの初期設定
        rb2 = GetComponent<Rigidbody2D>();

        Instantiate(createEffect, new Vector3(transform.position.x + 2.0f, 
        transform.position.y + 0.5f, 0.0f), Quaternion.identity);

        rb2.bodyType = RigidbodyType2D.Dynamic;

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
        transform.Translate(1.8f, 1.0f, 0.0f);
    }
}