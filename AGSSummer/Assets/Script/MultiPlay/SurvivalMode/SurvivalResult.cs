using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SurvivalResult : MonoBehaviour
{
    public bool loseFlag;

    public Text winText;
    public Text loseText;

    //private bool playerPlay;        //true:プレイヤー操作可能、false:プレイヤー操作不可


    private GameObject playerNumber;
    private GetPlayerNumber getPlayerNumber;

    private GameObject gameResult;
    private ResultProcess resultScript;


    private GameObject playerLife;
    private Life lifeScript;

    public GameObject root; //一番上の親を取得する
    // Start is called before the first frame update
    void Start()
    {

       // playerPlay = true;

        winText = winText.GetComponent<Text>();
        loseText = loseText.GetComponent<Text>();

        winText.enabled = false;
        loseText.enabled = false;

        playerNumber = GameObject.Find("GetPlayerNumber");
        getPlayerNumber = playerNumber.GetComponent<GetPlayerNumber>();

        gameResult = GameObject.Find("ResultManager");
        resultScript = gameResult.GetComponent<ResultProcess>();


        root = transform.root.gameObject;

        if (root == getPlayerNumber.getNumber[0])
        {
            playerLife = GameObject.Find("Life (1)");
        }
        else if (root == getPlayerNumber.getNumber[1])
        {
            playerLife = GameObject.Find("Life (2)");
        }
        else if (root == getPlayerNumber.getNumber[2])
        {
            playerLife = GameObject.Find("Life (3)");
        }
        else if (root == getPlayerNumber.getNumber[3])
        {
            playerLife = GameObject.Find("Life (4)");
        }

        lifeScript = playerLife.GetComponent<Life>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!loseFlag && resultScript.winFlag)
        {
            winText.enabled = true;
        }

        if (!loseFlag)
        {
            if (lifeScript.life == 0)
            {
                loseText.enabled = true;
                loseFlag = true;
                resultScript.AddLosePlayer();
            }
        }

        Debug.Log("lose" + loseFlag);

    }
}
