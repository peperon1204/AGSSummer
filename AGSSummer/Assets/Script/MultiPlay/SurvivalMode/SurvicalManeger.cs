using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SurvicalManeger : MonoBehaviour
{
    public bool win;        //本来はprivate
    public bool lose;       //テストのためにpublic

    public Text winText;
    public Text loseText;

    private GameObject playerLife;
    private Life lifeScript;

    private int survivalLife;

    // Start is called before the first frame update
    void Start()
    {
        win = false;
        lose = false;


        winText = winText.GetComponent<Text>();
        loseText = loseText.GetComponent<Text>();


        //ライフオブジェクトからライフを取得
        playerLife = GameObject.Find("Life");
        lifeScript = playerLife.GetComponent<Life>();

        winText.enabled = false;
        loseText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        survivalLife = lifeScript.life;

        Debug.Log("survivalLife" + survivalLife);

        if(win)
        {
            winText.enabled = true;
            loseText.enabled = false;
        }
        else if (lose)
        {
            winText.enabled = false;

            if (survivalLife == 0)
            {
                loseText.enabled = true;
            }
            else
            {
                loseText.enabled = false;
            }
        }
        else
        {
            winText.enabled = false;
            loseText.enabled = false;
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (win)
            {
                win = false;
            }
            else
            {
                win = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (lose)
            {
                lose = false;
            }
            else
            {
                lose = true;
            }
        }
    }
}
