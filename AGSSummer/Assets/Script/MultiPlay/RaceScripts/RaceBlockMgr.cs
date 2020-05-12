using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceBlockMgr : MonoBehaviour
{
    public RaceBlockNext raceBlockNext;

    public RaceFall raceFall;

    public RaceCtrl raceCtrl;

    public GameObject timer;

    private bool startCheck;

    private float timeCheck; 

    private bool start;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        startCheck = timer.GetComponent<Timer>().StartCheck();

        start = startCheck;

        timeCheck = timer.GetComponent<Timer>().TimerCheck();

        time = timeCheck;

        if(!start)
        {
            raceBlockNext.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!start)
        {
            time -= Time.deltaTime;

            if(time <= 0)
            {
                raceBlockNext.enabled = true;
                start = true;
            }
        }
        
        Debug.Log (start);
    }
}
