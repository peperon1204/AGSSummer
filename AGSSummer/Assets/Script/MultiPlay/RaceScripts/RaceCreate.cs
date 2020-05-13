using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCreate : MonoBehaviour
{
    public GameObject creatorMgr;

    public GameObject[] blockList;

    private int blockNumber;

    private float stayTime;

    private bool objUp;

    // Start is called before the first frame update
    void Start()
    {
        //乱数取得
        blockNumber = Random.Range(0, blockList.Length);

        Instantiate(blockList[blockNumber], transform.position, Quaternion.identity);

        objUp = false;

        stayTime = 0;
    }

    void Update()
    {
        Vector3 creatorPos = creatorMgr.transform.position;
        transform.position = new Vector3(creatorPos.x, creatorPos.y, 0.0f);

        if(stayTime >= 3)
        {
            objUp = true;
        }

        //段々と上に上がっていく
        if (objUp)
        {
            transform.Translate(0.0f, 0.1f, 0.0f);
        }
    }

    public void Create()
    {
        blockNumber = Random.Range(0, blockList.Length);

        Instantiate(blockList[blockNumber], transform.position, Quaternion.identity);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Block")
        {
            stayTime += Time.deltaTime;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Block")
        {
            stayTime = 0;
            objUp = false;
        }
    }
}
