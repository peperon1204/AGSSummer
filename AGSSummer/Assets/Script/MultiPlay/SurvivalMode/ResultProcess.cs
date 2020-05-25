using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultProcess : MonoBehaviour
{
    private int losePlayer;

    public bool winFlag;

    private GameObject getPlayerObject;

    private GetNumber getNumberScript;

    public int playerNumber;
    // Start is called before the first frame update
    void Start()
    {
        losePlayer = 0;
        winFlag = false;

        getPlayerObject = GameObject.Find("GetPlayer");
        getNumberScript = getPlayerObject.GetComponent<GetNumber>();
        playerNumber = getNumberScript.Number;
    }

    // Update is called once per frame
    void Update()
    {
        if(losePlayer >= playerNumber - 1)
        {
            winFlag = true;
        }

        Debug.Log("lose" + losePlayer);
    }

    public void AddLosePlayer()
    {
        losePlayer++;
    }
}
