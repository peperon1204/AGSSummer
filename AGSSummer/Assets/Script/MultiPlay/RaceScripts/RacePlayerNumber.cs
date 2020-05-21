using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacePlayerNumber : MonoBehaviour
{
    public GameObject[] getNumber;

    public GameObject[] blockCreatePoint;

    private GameObject getPlayerObject;

    private GetNumber getNumberScript;

    private int playerNumber;

    public Camera player1Camera;
    public Camera player2Camera;
    public Camera player3Camera;

    // Start is called before the first frame update
    void Start()
    {
        getPlayerObject = GameObject.Find("GetPlayer");
        getNumberScript = getPlayerObject.GetComponent<GetNumber>();
        playerNumber = getNumberScript.Number;
        Debug.Log(playerNumber);
        Destroy(getPlayerObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerNumber < 4)
        {
            getNumber[3].SetActive(false);

            if(playerNumber < 3)
            {
                getNumber[2].SetActive(false);

                player1Camera.rect = new Rect(0.0f, 0.0f, 0.5f, 1.0f);
                player2Camera.rect = new Rect(0.5f, 0.0f, 0.5f, 1.0f); 
            }
            else if (playerNumber == 3)
            {
                player1Camera.rect = new Rect(0.0f, 0.0f, 0.333f, 1.0f);
                player2Camera.rect = new Rect(0.333f, 0.0f, 0.333f, 1.0f);
                player3Camera.rect = new Rect(0.666f, 0.0f, 0.334f, 1.0f);
            }
        }
    }
}
