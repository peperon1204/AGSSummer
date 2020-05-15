using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayer : MonoBehaviour
{
    public int playerNumber;

    // Start is called before the first frame update
    void Start()
    {
        playerNumber = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            playerNumber++;
        }
        else if(Input.GetKeyDown(KeyCode.O))
        {
            playerNumber--;
        }

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
