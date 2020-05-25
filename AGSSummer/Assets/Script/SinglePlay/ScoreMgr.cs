using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreMgr : MonoBehaviour
{

    public int scorePoint = 0;

    private int score;
    public Text scoreText;

    public int tmpScore;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + score + "m";
        tmpScore = score;
    }

    public void ScoreAdd()
    {
        score += scorePoint;
    }
}
