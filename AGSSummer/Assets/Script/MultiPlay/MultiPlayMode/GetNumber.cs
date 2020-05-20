using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetNumber : MonoBehaviour
{
    private int number;

    private bool playGame;

    public Text numberText;

    // Start is called before the first frame update
    void Start()
    {
        number = 1;
        playGame = false;
        DontDestroyOnLoad (this);
    }

    // Update is called once per frame
    void Update()
    {
        if(!playGame)
        {
            if(number < 4)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    number += 1;
                }
            }

            if(number > 1)
            {
                if(Input.GetMouseButtonDown(1))
                {
                    number -= 1;
                }
            }
        }
        numberText.text = number.ToString();
    }
}
