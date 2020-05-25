using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBlockDestroy : MonoBehaviour
{
    public GameObject ItemDestroyBox;

    public bool destroyBox;

    
    // Start is called before the first frame update
    void Start()
    {
        destroyBox = false;
    }

    // Update is called once per frame
    void Update()
    {
        //左右移動
        if (Input.GetKey(KeyCode.W))
        {
            ItemDestroyBox.transform.Translate(1.0f, 0.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            ItemDestroyBox.transform.Translate(-1.0f, 0.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.E))
        {
            ItemDestroyBox.transform.Translate(0.0f, 0.1f, 0.0f);
        }

        if (Input.GetKey(KeyCode.R))
        {
            ItemDestroyBox.transform.Translate(0.0f, -0.1f, 0.0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            destroyBox = true;
        }

        Debug.Log(destroyBox);
    }


    void OnTriggerStay2D(Collider2D collision)
    {
        if (destroyBox)
        {
            if (collision.gameObject.tag == "BlockWaiver")
            {
                Destroy(collision.gameObject);
                destroyBox = false;
            }
        }
    }
}
