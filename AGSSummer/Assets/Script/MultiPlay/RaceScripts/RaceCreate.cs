using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCreate : MonoBehaviour
{
    public GameObject[] blockList;
    private int blockNumber;

    private float stayTime;

    // Start is called before the first frame update
    void Start()
    {
        //乱数取得
        blockNumber = Random.Range(0, blockList.Length);

        Instantiate(blockList[blockNumber], transform.position, Quaternion.identity);

        stayTime = 0;
    }

    void Update()
    {
        //段々と上に上がっていく
        if (stayTime >= 5)
        {
            transform.Translate(0.0f, 1.0f, 0.0f);
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
        }
    }
}
