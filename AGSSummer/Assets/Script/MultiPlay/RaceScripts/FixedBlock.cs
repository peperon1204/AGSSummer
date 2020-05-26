using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedBlock : MonoBehaviour
{
    private bool fixedPermit;

    private bool fixedBlock;

    private float fixedTimer;

    private GameObject playerNumber;
    
    private RacePlayerNumber getPlayerNumber;

    public GameObject root;

    private bool startFixed;

    // Start is called before the first frame update
    void Start()
    {
        fixedTimer = 0;
        fixedPermit = false;
        startFixed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(fixedBlock)
        {
            fixedTimer += Time.deltaTime;
            if(fixedTimer >= 3)
            {
                fixedPermit = true;
            }
        }
        else
        {
            fixedTimer = 0;
        }

        if(fixedPermit)
        {
            if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.V))
            {
                StartCoroutine("NextFramestartFixed");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        fixedBlock = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        fixedBlock = false;
    }

    IEnumerator NextFramestartFixed()
    {
        yield return null;

        startFixed = false;
    }

    public bool FixedPermit
    {
        get { return fixedPermit; }
        private set { fixedPermit = value; }
    }

    public bool StartFixed
    {
        get { return startFixed; }
        private set { startFixed = value; } 
    }
}
