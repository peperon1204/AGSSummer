using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDownPoint : MonoBehaviour
{
    public GameObject blockCreate;

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
        Vector3 createPos = blockCreate.transform.position;
        transform.position = new Vector3(createPos.x, createPos.y, 0.0f);

        if (transform.position.y < 3.0f)
        {
            transform.position = new Vector3(createPos.x, 3.0f, 0.0f);
        }

        if (objDown)
        {
            stayTime += Time.deltaTime;
            if (stayTime >= 2)
            {
                transform.Translate(0.0f, -0.05f, 0.0f);
            }
        }
        else
        {
            stayTime = 0;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        objDown = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        objDown = true;
    }
}
