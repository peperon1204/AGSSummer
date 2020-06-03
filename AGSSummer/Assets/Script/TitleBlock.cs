using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBlock : MonoBehaviour
{
    public GameObject createMgr;

    public GameObject[] blockList;

    private int blockNumber;

    private bool blockMove;

    private int blockTimeCnt;

    public int blockMax;
    private int blockCnt;

    public bool blockCreate;

    // Start is called before the first frame update
    void Start()
    {
        blockMove = false;

        blockTimeCnt = 0;


        blockCnt = 0;

        blockCreate = false;

    //乱数取得
    blockNumber = Random.Range(0, blockList.Length);

        //Instantiate(blockList[blockNumber], transform.position + blockList[blockNumber].transform.position, Quaternion.identity);

        

       
    }

    void Update()
    {
        Vector3 createPos = createMgr.transform.position;
        transform.position = new Vector3(createPos.x , createPos.y, 0.0f);
        if (blockCreate)
        {
            if (blockTimeCnt > 30)
            {
                blockTimeCnt = 0;
                blockMove = true;
            }
        }

        if(blockMove)
        {
            transform.position = new Vector3(transform.position.x + Random.Range(-8.0f, 8.0f), transform.position.y, 0.0f);
            Create();
            blockMove = false;

        }
        else
        {
            transform.position = new Vector3(0.0f, createPos.y, 0.0f);
        }
       
        if (!blockCreate)
        {
            blockCreate = true;
        }
        if (blockCnt > blockMax)
        {
            blockCreate = false;
            blockCnt = 0;
        }


        blockTimeCnt++;

        Debug.Log(blockCnt);
        Debug.Log(blockCreate);
    }

    public void Create()
    {
        blockNumber = Random.Range(0, blockList.Length);

        Instantiate(blockList[blockNumber], transform.position + blockList[blockNumber].transform.position, Quaternion.identity);
        blockCnt++;
    }
}

