using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalCameraMgr : MonoBehaviour
{
    //public GameObject[] blockCreatePoint;


    private GameObject playerNumber;
    private GetPlayerNumber getPlayerNumber;

    public GameObject root; //一番上の親を取得する

    private int playerMax;

    // Start is called before the first frame update
    void Start()
    {
        playerNumber = GameObject.Find("GetPlayerNumber");
        getPlayerNumber = playerNumber.GetComponent<GetPlayerNumber>();

        playerMax = 4;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i > playerMax; i++)
        {
           //Vector3 createPos[i] = blockCreatePoint[i].transform.position;
        }

           // Vector3 createPos = blockCreatePoint[1].transform.position;
       // Vector3 createPos = blockCreatePoint[0].transform.position;

       // transform.position = new Vector3(0, createPos.y - 4 , -10);
        //Vector3 createPos = blockCreatePoint[0].transform.position;

        root = transform.root.gameObject;



        if (root == getPlayerNumber.getNumber[0])
        {
            Vector3 createPos = getPlayerNumber.blockCreatePoint[0].transform.position;
            transform.position = new Vector3(createPos.x + 1.5f, createPos.y - 3, -10);
        }
        else if (root == getPlayerNumber.getNumber[1])
        {
            Vector3 createPos = getPlayerNumber.blockCreatePoint[1].transform.position;
            transform.position = new Vector3(createPos.x + 1.5f, createPos.y - 3, -10);
        }
        else if (root == getPlayerNumber.getNumber[2])
        {
            Vector3 createPos = getPlayerNumber.blockCreatePoint[2].transform.position;
            transform.position = new Vector3(createPos.x + 1.5f, createPos.y - 3, -10);
        }
        else if (root == getPlayerNumber.getNumber[3])
        {
            Vector3 createPos = getPlayerNumber.blockCreatePoint[3].transform.position;
            transform.position = new Vector3(createPos.x + 1.5f, createPos.y - 3, -10);
        }

        //Debug.Log("root" + root);


    }
}
