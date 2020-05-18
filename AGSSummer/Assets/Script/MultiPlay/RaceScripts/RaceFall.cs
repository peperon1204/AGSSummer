using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceFall : MonoBehaviour
{
    private Rigidbody2D rb2;

    private bool speedFall;

    public float normalSpeed;

    public float highSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyの初期設定
        rb2 = GetComponent<Rigidbody2D>();

        rb2.bodyType = RigidbodyType2D.Dynamic;

        transform.Translate(3.0f, 6.0f, 0.0f);

        //落下速度
        speedFall = false;
    }

    // Update is called once per frame
    void Update()
    {
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
