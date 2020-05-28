using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceBlockDestroy : MonoBehaviour
{
    private GameObject playerNumber;
    
    private RacePlayerNumber getPlayerNumber;

    public GameObject root;

    private bool destroyMove;

    private GameObject FixedObj;

    private FixedBlock darumaItem;
    
    // Start is called before the first frame update
    void Start()
    {
        playerNumber = GameObject.Find("GetPlayerNumber");
        getPlayerNumber = playerNumber.GetComponent<RacePlayerNumber>();

        root = transform.root.gameObject;

        if (root == getPlayerNumber.getNumber[0])
        {
            FixedObj = GameObject.Find("FixedObj (1)");
        }
        else if (root == getPlayerNumber.getNumber[1])
        {
            FixedObj = GameObject.Find("FixedObj (2)");
        }
        else if (root == getPlayerNumber.getNumber[2])
        {
            FixedObj = GameObject.Find("FixedObj (3)");
        }
        else if (root == getPlayerNumber.getNumber[3])
        {
            FixedObj = GameObject.Find("FixedObj (4)");
        }

        darumaItem = FixedObj.GetComponent<FixedBlock>();

        destroyMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(darumaItem.DarumaItem)
        {
            if (root == getPlayerNumber.getNumber[0])
            {
                if(Input.GetKeyDown(KeyCode.Z))
                {
                    destroyMove = true;
                }
                        }
                        else if (root == getPlayerNumber.getNumber[1])
                        {
                            if(Input.GetKeyDown(KeyCode.X))
                            {
                                destroyMove = true;
                            }
                        }
                        else if (root == getPlayerNumber.getNumber[2])
                        {
                            if(Input.GetKeyDown(KeyCode.C))
                            {
                                destroyMove = true;
                            }
                        }
                        else if (root == getPlayerNumber.getNumber[3])
                        {
                            if(Input.GetKeyDown(KeyCode.V))
                            {
                                destroyMove = true;
                            }
                        }
        }

        if(destroyMove)
        {
            transform.Translate(0.5f, 0.0f, 0.0f);
        }

        if(transform.position.x >= 35)
        {
            destroyMove = false;
            transform.position = new Vector3(-5.0f, -4.5f, 0.0f);
        }
    }


    void OnTriggerStay2D(Collider2D collision)
    {
        if(destroyMove)
        {
            Destroy(collision.gameObject);
        }
    }
}