﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetNumber : MonoBehaviour
{
    private int number;

    public bool playGame;

    public Text numberText;

    // Start is called before the first frame update
    void Start()
    {
        number = 3;
        playGame = false;
        DontDestroyOnLoad (this);
    }

    // Update is called once per frame
    void Update()
    {
        numberText.text = number.ToString();
    }

    public int Number
    {
        get{ return number; }  //取得用
        private set{ number = value; }　//値入力用
    }

    public void PlayerPlusCount()
    {
        if(number < 4)
        {
            number += 1;
        }
    }

    public void PlayerMinusCount()
    {
        if(number > 1)
        {
            number -= 1;
        }    
    }
}
