using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceBlockScript : MonoBehaviour
{

    private GameObject root; //一番上の親を取得する


    // Start is called before the first frame update
    void Start()
    {
        root = transform.root.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if(root.tag == "BlockWaiver")
        {
            gameObject.tag = "BlockWaiver";

        }
    }

   
}
