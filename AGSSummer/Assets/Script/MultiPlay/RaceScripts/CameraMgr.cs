﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMgr : MonoBehaviour
{
    public  GameObject  createMgr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 createPos = createMgr.transform.position;

        transform.position = new Vector3(createPos.x + 1.8f, createPos.y - 4, -10);
    }
}
