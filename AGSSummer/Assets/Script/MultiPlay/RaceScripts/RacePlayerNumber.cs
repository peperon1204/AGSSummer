using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacePlayerNumber : MonoBehaviour
{
    public GameObject[] getNumber;

    public GameObject[] blockCreatePoint;

    public RectTransform[] goalRectTransform;

    private GameObject getPlayerObject;

    private GetNumber getNumberScript;

    private int playerNumber;

    public Camera[] playerCamera;

    public RectTransform[] ItemRectTransform;

    void Awake()
    {
        playerNumber = 4;
    }

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

                playerCamera[0].rect = new Rect(0.0f, 0.0f, 0.5f, 1.0f);
                playerCamera[1].rect = new Rect(0.5f, 0.0f, 0.5f, 1.0f);

                goalRectTransform[0].localPosition = new Vector3(-250.0f, 0.0f, 0.0f);
                goalRectTransform[1].localPosition = new Vector3(250.0f, 0.0f, 0.0f);

                ItemRectTransform[0].localPosition = new Vector3(-250.0f, 0.0f, 0.0f);
                ItemRectTransform[1].localPosition = new Vector3(250.0f, 0.0f, 0.0f);
            }
            else if (playerNumber == 3)
            {
                playerCamera[0].rect = new Rect(0.0f, 0.0f, 0.333f, 1.0f);
                playerCamera[1].rect = new Rect(0.333f, 0.0f, 0.333f, 1.0f);
                playerCamera[2].rect = new Rect(0.666f, 0.0f, 0.334f, 1.0f);

                goalRectTransform[0].localPosition = new Vector3(-312.5f, 0.0f, 0.0f);
                goalRectTransform[1].localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                goalRectTransform[2].localPosition = new Vector3(312.5f, 0.0f, 0.0f);

                ItemRectTransform[0].localPosition = new Vector3(-312.5f, 0.0f, 0.0f);
                ItemRectTransform[1].localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                ItemRectTransform[2].localPosition = new Vector3(312.5f, 0.0f, 0.0f);
            }
        }
    }
}
