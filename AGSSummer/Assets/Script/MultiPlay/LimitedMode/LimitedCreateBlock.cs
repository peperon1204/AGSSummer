using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedCreateBlock : MonoBehaviour
{
   
    public GameObject[] blockPattern1;      //この３つは
    public GameObject[] blockPattern2;      //あとで直す
    public GameObject[] blockPattern3;      //


    private int patternNumber;
    private int blockNumber;

  //  private bool test; 

    void Start()
    {
        patternNumber = Random.Range(0, 3);

        blockNumber = 0;
        //test = false;
        Create();

    }

    void Update()
    {
      
        if(blockNumber > 2)
        {
            blockNumber = 0;
        }

    }

    public void Create()
    {
       switch(patternNumber)
        {
            case 0:
                Instantiate(blockPattern1[blockNumber], new Vector3(0, 6 ,0), Quaternion.identity);
                break;
            case 1:
                Instantiate(blockPattern2[blockNumber], new Vector3(0, 6, 0), Quaternion.identity);
                break;
            case 2:
                Instantiate(blockPattern3[blockNumber], new Vector3(0, 6, 0), Quaternion.identity);
                break;
            default:            
                break;
        }

        //if (!test)
        //{

        //    test = true;
        //    if (test)
        //    {
        //        //Create();
        //        test = false;
                blockNumber++;

      //    }
      //
        //}
    }

    //void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Block")
    //    {
    //        stayTime += Time.deltaTime;
    //    }
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Block")
    //    {
    //        stayTime = 0;
    //    }
    //}
}

