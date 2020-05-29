using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SingleMode : MonoBehaviour
{

    public enum GameModeScene
    {
        Start,
        Play,
        Result
    }

    public GameModeScene gameMode;

    private GameObject countdownObject;
    private TimerControl countdownScript;

    private GameObject tmpScoreObject;
    private ScoreMgr scoreScript;

    public Text gameScore;
    public Text gameTime;

    public Text resultScore;
    public Text resultText1;
    public Text resultText2;

    public Text returnTitle;


    // Start is called before the first frame update
    void Start()
    {
        gameMode = GameModeScene.Start;

        countdownObject = GameObject.Find("Countdown");
        countdownScript = countdownObject.GetComponent<TimerControl>();

        tmpScoreObject = GameObject.Find("ScoreMgr");
        scoreScript = tmpScoreObject.GetComponent<ScoreMgr>();

        resultScore.enabled = false;
        resultText1.enabled = false;
        resultText2.enabled = false;
        returnTitle.enabled = false;

        gameScore.enabled = true;
        gameTime.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(countdownScript.totalTime <= 0)
        {
            gameMode = GameModeScene.Result;
        }

        resultScore.text = "Score" + scoreScript.tmpScore + "m";

        if (gameMode == GameModeScene.Result)
        {
            resultScore.enabled = true;
            resultText1.enabled = true;
            //resultText2.enabled = true;
            returnTitle.enabled = true;

            gameScore.enabled = false;
            gameTime.enabled = false;

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
