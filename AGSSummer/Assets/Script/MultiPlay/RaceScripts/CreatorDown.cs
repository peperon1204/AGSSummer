using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorDown : MonoBehaviour
{
    public GameObject blockCreator;

    private bool objDown;

    private float stayTime;

    // Start is called before the first frame update
    void Start()
    {
        objDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 creatorPos = blockCreator.transform.position;
        transform.position = new Vector3(creatorPos.x, creatorPos.y, 0.0f);

        if(objDown)
        {
            stayTime += Time.deltaTime;
            if(stayTime >= 1)
            {
                transform.Translate(0.0f, -0.1f, 0.0f);
            }
        }
        else
        {
            stayTime = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BlockWaiver" || other.gameObject.tag == "Floor")
        {
            objDown = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "BlockWaiver" || other.gameObject.tag == "Floor")
        {
            objDown = true;
        }
    }
}
