using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Life : MonoBehaviour
{
    public int life;                    //プレイヤーライフ
    private int lifeMax;                //ライフ最大値
   // public Image[] lifeImg;             //ライフ画像
   // public Image[] lifeLostImg;         //ライフ減少時画像

    public GameObject[] playerLife;             //ライフ画像
    public GameObject[] playerLifeLost;         //ライフ減少時画像

    public GameObject heartEffect;

    private bool lostFlag;

    // Start is called before the first frame update
    void Start()
    {
        lostFlag = false;

        life = 3;
        lifeMax = life;//プレイヤーライフ取得


        /*for (int i = 0; i > lifeMax; i++)
        {
            lifeImg[i] = lifeImg[i].GetComponent<Image>();
            lifeLostImg[i] = lifeLostImg[i].GetComponent<Image>();
        }*/

        for (int i = 0; i > lifeMax; i++)
        {
            //playerLife[i] = playerLife[i].GetComponent<GameObject>();
            //playerLifeLost[i] = playerLifeLost[i].GetComponent<GameObject>();

            //playerLife[i].SetActive(true);
            //playerLifeLost[i].SetActive(false);
        }

        playerLife[0].SetActive(true);
        playerLifeLost[0].SetActive(false);
        playerLife[1].SetActive(true);
        playerLifeLost[1].SetActive(false);
        playerLife[2].SetActive(true);
        playerLifeLost[2].SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.A))
        {
            life--;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            life++;
        }


        if (life <= 2)
        {
            playerLife[2].SetActive(false);
            playerLifeLost[2].SetActive(true);
        }
        if (life <= 1)
        {
            playerLife[1].SetActive(false);
            playerLifeLost[1].SetActive(true);
        }
        if (life <= 0)
        {
            playerLife[0].SetActive(false);
            playerLifeLost[0].SetActive(true);
        }


        if (life > 2)
        {
            playerLife[2].SetActive(true);
            playerLifeLost[2].SetActive(false);
        }
        if (life > 1)
        {
            playerLife[1].SetActive(true);
            playerLifeLost[1].SetActive(false);
        }
        if (life > 0)
        {
            playerLife[0].SetActive(true);
            playerLifeLost[0].SetActive(false);
        }

        if (life > lifeMax)
        {
            life = lifeMax;
        }
        else if(life < 0)
        {
            life = 0;
        }

        Debug.Log("Life" + life);
        Debug.Log("LifeMax" + lifeMax);
    }

    public void LifeLost()
    {
        lostFlag = true;
        life--;
        if (lostFlag)
        {
            if (life <= 2)
            {
                Instantiate(heartEffect, playerLife[2].transform.position, Quaternion.identity); //エフェクト生成
                lostFlag = false;
            }
            if (life <= 1)
            {
                Instantiate(heartEffect, playerLife[1].transform.position, Quaternion.identity); //エフェクト生成
                lostFlag = false;
            }
            if (life <= 0)
            {
                Instantiate(heartEffect, playerLife[0].transform.position, Quaternion.identity); //エフェクト生成
                lostFlag = false;
            }
        }
    }
}
