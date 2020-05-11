using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MultiModeSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Invoke("ChangeSceneRaceMode", 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Invoke("ChangeSceneSurvivalMode", 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Invoke("ChangeSceneLimited", 0.0f);
        }
    }

    void ChangeSceneRaceMode()
    {
        SceneManager.LoadScene("RaceMode");
    }

    void ChangeSceneSurvivalMode()
    {
        SceneManager.LoadScene("SurvivalMode");
    }

    void ChangeSceneLimited()
    {
        SceneManager.LoadScene("LimitedMode");
    }
}
