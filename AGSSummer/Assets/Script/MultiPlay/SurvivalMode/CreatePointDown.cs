using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePointDown : MonoBehaviour
{
    public GameObject blockCreator;

    private bool objDown;

    private float stayTime;

    private GameObject loseProcessObject;
    private SurvivalResult loseScript;

    private GameObject gameResult;
    private ResultProcess resultScript;

    public GameObject root; //一番上の親を取得する

    private GameObject playerNumber;
    private GetPlayerNumber getPlayerNumber;

    // Start is called before the first frame update
    void Start()
    {

        objDown = false;


        gameResult = GameObject.Find("ResultManager");
        resultScript = gameResult.GetComponent<ResultProcess>();

        root = transform.root.gameObject;

        playerNumber = GameObject.Find("GetPlayerNumber");
        getPlayerNumber = playerNumber.GetComponent<GetPlayerNumber>();


        if (root == getPlayerNumber.getNumber[0])
        {
            loseProcessObject = GameObject.Find("Player1");
        }
        else if (root == getPlayerNumber.getNumber[1])
        {
            loseProcessObject = GameObject.Find("Player2");
        }
        else if (root == getPlayerNumber.getNumber[2])
        {
            loseProcessObject = GameObject.Find("Player3");
        }
        else if (root == getPlayerNumber.getNumber[3])
        {
            loseProcessObject = GameObject.Find("Player4");
        }

        loseScript = loseProcessObject.GetComponent<SurvivalResult>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 creatorPos = blockCreator.transform.position;
        transform.position = new Vector3(creatorPos.x, creatorPos.y, 0.0f);
        if (!loseScript.loseFlag && !resultScript.winFlag)
        {
            if (objDown)
            {
                stayTime += Time.deltaTime;
                if (stayTime >= 1)
                {
                    transform.Translate(0.0f, -0.1f, 0.0f);
                }
            }
            else
            {
                stayTime = 0;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //if (other.gameObject.tag == "BlockWaiver" || other.gameObject.tag == "Floor")
        {
            objDown = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
       // if (other.gameObject.tag == "BlockWaiver" || other.gameObject.tag == "Floor")
        {
            objDown = true;
        }
    }
}
