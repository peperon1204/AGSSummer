using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCtrl : MonoBehaviour
{
    private Transform child;

    private bool ctrlWaiver;

    private GameObject playerNumber;

    private RacePlayerNumber getPlayerNumber;

    public GameObject root;

    private RaceFall raceFall;

    public AudioClip blockSe;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerNumber = GameObject.Find("GetPlayerNumber");

        getPlayerNumber = playerNumber.GetComponent<RacePlayerNumber>();

        root = transform.root.gameObject;

        raceFall = gameObject.GetComponent<RaceFall>();

        audioSource = GetComponent<AudioSource>();

        //回転する中心軸を取得
        child = transform.Find("RotationCenter");

        ctrlWaiver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (root == getPlayerNumber.getNumber[0])
        {
            if(!ctrlWaiver)
            {
                //スペースで高速落下開始
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    //高速落下したら移動と回転ができなくなるよ
                    ctrlWaiver = true;
                    raceFall.speedFall = true;
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
                    audioSource.PlayOneShot(blockSe);
                    
                    child.transform.Rotate(0.0f, 0.0f, 90.0f);
                }
            }
        }

        if (root == getPlayerNumber.getNumber[1])
        {
            if(!ctrlWaiver)
            {
                //スペースで高速落下開始
                if (Input.GetKeyDown(KeyCode.S))
                {
                    //高速落下したら移動と回転ができなくなるよ
                    ctrlWaiver = true;
                    raceFall.speedFall = true;
                }

                //左右移動
                if (Input.GetKeyDown(KeyCode.D))
                {
                    transform.Translate(0.16f, 0.0f, 0.0f);
                }

                if (Input.GetKeyDown(KeyCode.A))
                {
                    transform.Translate(-0.16f, 0.0f, 0.0f);
                }

                //子オブジェクト（中心軸）のRotationを回転させる
                if (Input.GetKeyDown(KeyCode.W))
                {
                    audioSource.PlayOneShot(blockSe);
                    
                    child.transform.Rotate(0.0f, 0.0f, 90.0f);
                }
            }
        }

        if (root == getPlayerNumber.getNumber[2])
        {
            if(!ctrlWaiver)
            {
                //スペースで高速落下開始
                if (Input.GetKeyDown(KeyCode.G))
                {
                    //高速落下したら移動と回転ができなくなるよ
                    ctrlWaiver = true;
                    raceFall.speedFall = true;
                }

                //左右移動
                if (Input.GetKeyDown(KeyCode.H))
                {
                    transform.Translate(0.16f, 0.0f, 0.0f);
                }

                if (Input.GetKeyDown(KeyCode.F))
                {
                    transform.Translate(-0.16f, 0.0f, 0.0f);
                }

                //子オブジェクト（中心軸）のRotationを回転させる
                if (Input.GetKeyDown(KeyCode.T))
                {
                    audioSource.PlayOneShot(blockSe);

                    child.transform.Rotate(0.0f, 0.0f, 90.0f);
                }
            }
        }

        if (root == getPlayerNumber.getNumber[3])
        {
            if(!ctrlWaiver)
            {
                //スペースで高速落下開始
                if (Input.GetKeyDown(KeyCode.K))
                {
                    //高速落下したら移動と回転ができなくなるよ
                    ctrlWaiver = true;
                    raceFall.speedFall = true;
                }

                //左右移動
                if (Input.GetKeyDown(KeyCode.L))
                {
                    transform.Translate(0.16f, 0.0f, 0.0f);
                }

                if (Input.GetKeyDown(KeyCode.J))
                {
                    transform.Translate(-0.16f, 0.0f, 0.0f);
                }

                //子オブジェクト（中心軸）のRotationを回転させる
                if (Input.GetKeyDown(KeyCode.I))
                {
                    audioSource.PlayOneShot(blockSe);

                    child.transform.Rotate(0.0f, 0.0f, 90.0f);
                }
            }
        }
    }
}
