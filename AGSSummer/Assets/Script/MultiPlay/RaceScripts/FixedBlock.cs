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

    private GameObject playerNumber;
    
    private RacePlayerNumber getPlayerNumber;

    public GameObject root;

    // Start is called before the first frame update
    void Start()
    {
        playerNumber = GameObject.Find("GetPlayerNumber");
        getPlayerNumber = playerNumber.GetComponent<RacePlayerNumber>();

        root = transform.root.gameObject;

        itemTimer = 0;
        getItem = false;
        randomItem = 0;
        fixedPermit = false;
        usedItem = true;
        darumaItem = false;

        ItemText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(getItem)
        {
            itemTimer += Time.deltaTime;
            if(itemTimer >= 3)
            {
                randomItem = Random.Range(1, 3);
                usedItem = false;
                getItem = false;
                ItemText.enabled = true;
            }
        }
        else
        {
            itemTimer = 0;
        }

        ItemText.text = randomItem.ToString();

        if(randomItem == 0)
        {
            fixedPermit = false;
            darumaItem = false;
        }
        else if(randomItem == 1)
        {
            fixedPermit = true;
        }
        else if(randomItem == 2)
        {
            darumaItem = true;
        }

        if(!usedItem)
        {
            if (root == getPlayerNumber.getNumber[0])
            {
                if(Input.GetKeyDown(KeyCode.Z))
                {
                    StartCoroutine("NextFramestartFixed");
                }
            }
            else if (root == getPlayerNumber.getNumber[1])
            {
                if(Input.GetKeyDown(KeyCode.X))
                {
                    StartCoroutine("NextFramestartFixed");
                }
            }
            else if (root == getPlayerNumber.getNumber[2])
            {
                if(Input.GetKeyDown(KeyCode.C))
                {
                    StartCoroutine("NextFramestartFixed");
                }
            }
            else if (root == getPlayerNumber.getNumber[3])
            {
                if(Input.GetKeyDown(KeyCode.V))
                {
                    StartCoroutine("NextFramestartFixed");
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(usedItem)
        {   
            getItem = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        getItem = false;
    }

    IEnumerator NextFramestartFixed()
    {
        yield return null;

        randomItem = 0;

        usedItem = true;

        ItemText.enabled = false;
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
