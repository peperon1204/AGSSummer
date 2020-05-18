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


    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyの初期設定
        rb2 = GetComponent<Rigidbody2D>();

        rb2.bodyType = RigidbodyType2D.Dynamic;



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
        transform.Translate(1.5f, 3.0f, 0.0f);

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
