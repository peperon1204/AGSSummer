using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacePlayerNumber : MonoBehaviour
{
    public GameObject[] getNumber;

    public GameObject[] blockCreatePoint;

    private GameObject getPlayerObject;

    private GetNumber getNumberScript;

    private Camera[] camera;

    private Rect[] camerarect;

    private int playerNumber;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            camera[i] = getNumber[i].GetComponent<Camera>();
            camerarect[i] = camera[i].rect;
        }

        getPlayerObject = GameObject.Find("GetPlayer");
        getNumberScript = getPlayerObject.GetComponent<GetNumber>();
        playerNumber = getNumberScript.Number;
        Debug.Log(playerNumber);
        getNumberScript.enabled = false;
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

                if(playerNumber < 2)
                {
                    getNumber[1].SetActive(false);

                    camerarect[0] = new Rect(0, 0, 1, 1);
                }
            }
        }
    }
}
