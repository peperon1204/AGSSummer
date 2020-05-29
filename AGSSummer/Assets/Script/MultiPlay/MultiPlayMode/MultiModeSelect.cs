using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MultiModeSelect : MonoBehaviour
{
    public AudioClip buttonSe;
    AudioSource audioSource; 

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    Invoke("ChangeSceneRaceMode", 0.0f);
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    Invoke("ChangeSceneSurvivalMode", 0.0f);
        //}
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    Invoke("ChangeSceneLimited", 0.0f);
        //}
    }

    void SceneRaceMode()
    {
        SceneManager.LoadScene("RaceMode");
    }

    void SceneSurvivalMode()
    {
        SceneManager.LoadScene("SurvivalMode");
    }

    //public void ChangeSceneLimited()
    //{
    //    SceneManager.LoadScene("LimitedMode");
    //}

    public void ChangeSceneRaceMode()
    {
        audioSource.PlayOneShot(buttonSe);

        Invoke("SceneRaceMode", 0.5f);
    }

    public void ChangeSceneSurvivalMode()
    {
        audioSource.PlayOneShot(buttonSe);
        Invoke("SceneSurvivalMode", 0.5f);
    }
}
