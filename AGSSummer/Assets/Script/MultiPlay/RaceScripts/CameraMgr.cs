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

        transform.position = new Vector3(0, createPos.y, -10);
    }
}
