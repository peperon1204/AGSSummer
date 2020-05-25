using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerNumber : MonoBehaviour
{
    public GameObject[] getNumber;

    public GameObject[] blockCreatePoint;

    private GameObject getPlayerObject;

    private GetNumber getNumberScript;

    public int playerNumber;


    // Start is called before the first frame update
    void Start()
    {
        getPlayerObject = GameObject.Find("GetPlayer");
        getNumberScript = getPlayerObject.GetComponent<GetNumber>();
        playerNumber = getNumberScript.Number;

        if (playerNumber == 4)
        {
            getNumber[0].SetActive(true);
            getNumber[1].SetActive(true);
            getNumber[2].SetActive(true);
            getNumber[3].SetActive(true);
        }
        else if (playerNumber == 3)
        {
            getNumber[0].SetActive(true);
            getNumber[1].SetActive(true);
            getNumber[2].SetActive(true);
            getNumber[3].SetActive(false);
        }
        else if (playerNumber == 2)
        {
            getNumber[0].SetActive(true);
            getNumber[1].SetActive(true);
            getNumber[2].SetActive(false);
            getNumber[3].SetActive(false);
        }
        else if (playerNumber == 1)
        {
            getNumber[0].SetActive(true);
            getNumber[1].SetActive(false);
            getNumber[2].SetActive(false);
            getNumber[3].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
