using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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

    public void ChangeSceneSingle()
    {
        SceneManager.LoadScene("SinglePlay");
    }

    public void ChangeSceneMulti()
    {
        SceneManager.LoadScene("MultiPlay");
    }
}
