using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createBlock : MonoBehaviour
{
    public GameObject[] blockList;
    private int blockNumber;

    // Start is called before the first frame update
    void Start()
    {
        //乱数取得
        blockNumber = Random.Range(0, blockList.Length);

        //ランダムにブロックの１つを生成
        Instantiate(blockList[blockNumber], transform.position, Quaternion.identity);
    }
    
    public void Create()
    {
        blockNumber = Random.Range(0, blockList.Length);

        Instantiate(blockList[blockNumber], transform.position, Quaternion.identity);
    }
}
