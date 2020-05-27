using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixedBlock : MonoBehaviour
{
    private bool getItem;

    private int randomItem;

    private float itemTimer;

    private bool fixedPermit;

    private bool usedItem;

    private bool darumaItem;

    public Text ItemText;

    // Start is called before the first frame update
    void Start()
    {
        itemTimer = 0;
        getItem = false;
        randomItem = 0;
        fixedPermit = false;
        usedItem = true;
        darumaItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        ItemText.text = (randomItem);

        if(getItem)
        {
            itemTimer += Time.deltaTime;
            if(itemTimer >= 3)
            {
                randomItem = Random.Range(1, 3);
                usedItem = false;
                getItem = false;
            }
        }
        else
        {
            itemTimer = 0;
        }

        if(randomItem == 1)
        {
            fixedPermit = true;
        }
        else if(randomItem == 2)
        {
            darumaItem = true;
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
        getItem = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        getItem = false;
        usedItem = true;
    }

    IEnumerator NextFramestartFixed()
    {
        yield return null;

        randomItem = 0;

        usedItem = true;
    }

    public bool FixedPermit
    {
        get { return fixedPermit; }
        private set { fixedPermit = value; }
    }

    public bool UsedItem
    {
        get { return usedItem; }
        private set { usedItem = value; } 
    }

    public bool DarumaItem
    {
        get { return darumaItem; }
        private set { darumaItem = value; }
    }
}
