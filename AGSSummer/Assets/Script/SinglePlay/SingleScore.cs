using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleScore : MonoBehaviour
{
    public GameObject scoreBox;

    private bool destroyFlag;

    private GameObject scoreObject;
    private ScoreMgr scoreScript;


    // Start is called before the first frame update
    void Start()
    {
        scoreObject = GameObject.Find("ScoreMgr");
        scoreScript = scoreObject.GetComponent<ScoreMgr>();


        destroyFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
    }


    void OnTriggerStay2D(Collider2D collision)
    {

        if (!destroyFlag)
        {
            if (collision.gameObject.tag == "BlockWaiver")
            {
                Instantiate(scoreBox, new Vector3(transform.position.x, transform.position.y + 5.0f, transform.position.z), Quaternion.identity);

                scoreScript.ScoreAdd();
                Debug.Log("当たり");

                Destroy(scoreBox);
                destroyFlag = true;
            }
        }
    }
}