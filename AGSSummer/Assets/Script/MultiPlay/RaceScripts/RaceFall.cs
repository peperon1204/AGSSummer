using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceFall : MonoBehaviour
{
    private Rigidbody2D rb2;

    private bool[] speedFall;

    public float normalSpeed;

    public float highSpeed;

    private GameObject playerNumber;
    
    private RacePlayerNumber getPlayerNumber;

    public GameObject root;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyの初期設定
        rb2 = GetComponent<Rigidbody2D>();

        rb2.bodyType = RigidbodyType2D.Dynamic;

        playerNumber = GameObject.Find("GetPlayerNumber");

        getPlayerNumber = playerNumber.GetComponent<RacePlayerNumber>();

        root = transform.root.gameObject;

        transform.Translate(2.0f, 6.0f, 0.0f);

        for(int i = 0; i < 4; i++)
        {
            //落下速度
            speedFall[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //rb2.velocity = Vector2.zero;

        /*for(int i = 0; i < 4; i++)
        {
            
        }*/

        if (getPlayerNumber.getNumber[1])
        {
            if (!speedFall[1])
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

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //落下速度を変えます
            speedFall[0] = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            //落下速度を変えます
            speedFall[1] = true;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            //落下速度を変えます
            speedFall[2] = true;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            //落下速度を変えます
            speedFall[3] = true;
        }
    }
}
