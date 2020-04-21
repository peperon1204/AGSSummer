using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createBlock : MonoBehaviour
{
    public GameObject[] blockList;
    private int blockNumber;

    private float stayTime;

    // Start is called before the first frame update
    void Start()
    {
        //乱数取得
        blockNumber = Random.Range(0, blockList.Length);

        //ランダムにブロックの１つを生成
        Instantiate(blockList[blockNumber], transform.position, Quaternion.identity);

        stayTime = 0;
    }

    void Update()
    {
        if(stayTime >= 5.0f)
        {
            transform.Translate(0.0f, 1.0f, 0.0f);
            stayTime = 0;
        }
    }   
    
    public void Create()
    {
        blockNumber = Random.Range(0, blockList.Length);

        Instantiate(blockList[blockNumber], transform.position, Quaternion.identity);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Block")
        {
            stayTime += Time.deltaTime;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Block")
        {
            stayTime = 0;
        }
    }

}
