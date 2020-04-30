using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createBlock : MonoBehaviour
{
    public GameObject[] blockList;
    private int blockNumber;

    private float stayTime;

    private bool start;

    private float Timer;
    private int seconds;
    public Text timeText;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        //乱数取得
        blockNumber = Random.Range(0, blockList.Length);

        stayTime = 0;

        start = true;

        Timer = 5;
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        seconds = (int)Timer;

        //timeText.text = seconds.ToString();
        
        //ランダムにブロックの１つを生成
        if (start && Timer<=0)
        {
            Create();
            start = false;
            //canvas.enabled = false;
        }

        if(stayTime >= 5)
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
