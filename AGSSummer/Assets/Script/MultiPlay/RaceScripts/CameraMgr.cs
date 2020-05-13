using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMgr : MonoBehaviour
{
    public  GameObject  blockCreator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 creatorPos = blockCreator.transform.position;

        transform.position = new Vector3(0, creatorPos.y - 3, -10);
    }
}
