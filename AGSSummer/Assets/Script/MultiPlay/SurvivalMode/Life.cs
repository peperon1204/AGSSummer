using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Life : MonoBehaviour
{
    public int life;                    //プレイヤーライフ
    private int lifeMax;                //ライフ最大値
    public Image[] lifeImg;             //ライフ画像
    public Image[] lifeLostImg;         //ライフ減少時画像


    // Start is called before the first frame update
    void Start()
    {

        life = 3;
        lifeMax = life;//プレイヤーライフ取得


        for (int i = 0; i > lifeMax; i++)
        {
            lifeImg[i] = GetComponent<Image>();
            lifeLostImg[i] = GetComponent<Image>();
        }

       
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

        if (life < 0)
        {
            life = 0;
        }
        if (life > lifeMax)
        {
            life = lifeMax;
        }


        if (life == 2)
        {
            lifeImg[2].enabled = false;
        }
        else if (life == 1)
        {
            lifeImg[1].enabled = false;
        }
        else if (life == 0)
        {
            lifeImg[0].enabled = false;
        }

        if (life > 2)
        {
            lifeImg[2].enabled = true;
        }
        else if (life > 1)
        {
            lifeImg[1].enabled = true;
        }
        else if (life > 0)
        {
            lifeImg[0].enabled = true;
        }

        Debug.Log("Life" + life);
        Debug.Log("LifeMax" + lifeMax);
    }
}
