using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayer : MonoBehaviour
{

    private GameObject getPlayerObject;

    private GetNumber getNumberScript;

    public int playerNumber;

    // Start is called before the first frame update
    void Start()
    {

        getPlayerObject = GameObject.Find("GetPlayer");
        getNumberScript = getPlayerObject.GetComponent<GetNumber>();
        playerNumber = getNumberScript.Number;

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    playerNumber++;
        //}
        //else if(Input.GetKeyDown(KeyCode.O))
        //{
        //    playerNumber--;
        //}

        if(playerNumber > 4)
        {
            playerNumber = 4;
        }
        else if(playerNumber < 1)
        {
            playerNumber = 1;
        }

        Debug.Log("playerNumber" + playerNumber);
    }
}
