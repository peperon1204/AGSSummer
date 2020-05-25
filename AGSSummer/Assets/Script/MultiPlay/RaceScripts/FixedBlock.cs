using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedBlock : MonoBehaviour
{
    private bool fixedPermit;

    private float fixedTimer;

    // Start is called before the first frame update
    void Start()
    {
        fixedTimer = 0;
        fixedPermit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(fixedTimer >= 3)
        {
            fixedPermit = true;
        }
        else
        {
            fixedPermit = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        fixedTimer += Time.deltaTime;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        fixedTimer = 0.0f;
    }

    public bool FixedPermit
    {
        get { return fixedPermit; }
        private set { fixedPermit = value; }
    }
}
