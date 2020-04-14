using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createBlock : MonoBehaviour
{
    public GameObject[] blockList;
    private int blockNumber;

    private float timeCreate;
    private bool timerStart = false;

    public float timeOut;
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        //乱数取得
        blockNumber = Random.Range(0, blockList.Length);

        //ランダムにブロックの１つを生成
        Instantiate(blockList[blockNumber], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerStart)
        {
            timeCreate += Time.deltaTime;

            //スペースまたは時間経過でブロック生成を開始
            if (Input.GetKeyDown(KeyCode.Space) || timeCreate >= 5)
            {
                timerStart = true;
                timeCreate = 0;
            }
        }

        if(timerStart)
        {
            //ブロック生成
            Create();
        }
    }

    void Create()
    {
        timeElapsed += Time.deltaTime;

        //時間経過で生成
        if (timeElapsed >= timeOut)
        {
            blockNumber = Random.Range(0, blockList.Length);
            Instantiate(blockList[blockNumber], transform.position, Quaternion.identity);
            timeElapsed = 0;
            timerStart = false;
        }
    }
}
