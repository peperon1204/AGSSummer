using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultProcess : MonoBehaviour
{
    private int losePlayer;

    public bool winFlag;

    // Start is called before the first frame update
    void Start()
    {
        losePlayer = 0;
        winFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(losePlayer >= 3)
        {
            winFlag = true;
        }

        Debug.Log("lose" + losePlayer);
    }

    public void AddLosePlayer()
    {
        losePlayer++;
    }
}
