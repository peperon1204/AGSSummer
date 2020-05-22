using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedBlock : MonoBehaviour
{
    private bool fixedBlock;

    private Rigidbody2D blockRb2;

    private RaceBlockMgr raceBlockMgr;

    // Start is called before the first frame update
    void Start()
    {
        fixedBlock = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(fixedBlock)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                blockRb2.bodyType = RigidbodyType2D.Static;
                raceBlockMgr.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if(other.gameObject.tag == "BlockWaiver")
        {
            blockRb2 = other.gameObject.GetComponent<Rigidbody2D>();
            raceBlockMgr = other.gameObject.GetComponent<RaceBlockMgr>();
            fixedBlock = true;
        }
    }
}
