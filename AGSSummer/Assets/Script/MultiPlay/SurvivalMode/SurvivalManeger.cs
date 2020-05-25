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

    private GameObject resultObject;
    private ResultProcess resultScript;

    public enum GameModeScene
    {
        Start,
        Play,
        Result
    }

    public GameModeScene gameMode;

    // Start is called before the first frame update
    void Start()
    {
        win = false;
        lose = false;


        winText = winText.GetComponent<Text>();
        loseText = loseText.GetComponent<Text>();


        playerNumber = GameObject.Find("GetPlayerNumber");
        getPlayerNumber = playerNumber.GetComponent<GetPlayerNumber>();


        resultObject = GameObject.Find("ResultManager");
        resultScript = resultObject.GetComponent<ResultProcess>();

        gameMode = GameModeScene.Start;

        winText.enabled = false;
        loseText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //survivalLife = lifeScript.life;

        //Debug.Log("survivalLife" + survivalLife);

        if(resultScript.winFlag)
        {
            gameMode = GameModeScene.Result;
        }


        if (gameMode == GameModeScene.Result)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Invoke("ChangeScene", 0.0f);
            }
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Title");
    }
}
