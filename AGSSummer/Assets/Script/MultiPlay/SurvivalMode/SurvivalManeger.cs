using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class SurvivalManeger : MonoBehaviour
{
    public bool win;        //本来はprivate
    public bool lose;       //テストのためにpublic

    public Text winText;
    public Text loseText;

    public GameObject[] playerLife;
    private Life[] lifeScript;

    //private int survivalLife;

    private GameObject playerNumber;
    private GetPlayerNumber getPlayerNumber;

    // Start is called before the first frame update
    void Start()
    {
        win = false;
        lose = false;


        winText = winText.GetComponent<Text>();
        loseText = loseText.GetComponent<Text>();


        playerNumber = GameObject.Find("GetPlayerNumber");
        getPlayerNumber = playerNumber.GetComponent<GetPlayerNumber>();


        //ライフオブジェクトからライフを取得
        //lifeScript[0] = playerLife[0].GetComponent<Life>();
        //lifeScript[1] = playerLife[1].GetComponent<Life>();
        //lifeScript[2] = playerLife[2].GetComponent<Life>();
        //lifeScript[3] = playerLife[3].GetComponent<Life>();

        winText.enabled = false;
        loseText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //survivalLife = lifeScript.life;

        //Debug.Log("survivalLife" + survivalLife);


        if (Input.GetKeyDown(KeyCode.Return))
        {
            Invoke("ChangeScene", 0.0f);
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Title");
    }
}
