using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
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
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    Invoke("ChangeSceneSingle", 0.0f);
        //}
        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    Invoke("ChangeSceneMulti", 0.0f);
        //}
    }

    void SceneSingle()
    {
        SceneManager.LoadScene("SinglePlay");
    }

    void SceneMulti()
    {
        SceneManager.LoadScene("MultiPlay");
    }

    public void ChangeSceneSingle()
    {
        audioSource.PlayOneShot(buttonSe);

        Invoke("SceneSingle", 0.5f);
    }

    public void ChangeSceneMulti()
    {
        audioSource.PlayOneShot(buttonSe);

        Invoke("SceneMulti", 0.5f);
    }
}
