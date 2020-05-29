using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ContinueBGM : MonoBehaviour
{
    public bool destroyBGM;

    // Start is called before the first frame update

    // Use this for initialization
    void Start()
    {
        destroyBGM = true;

        if (destroyBGM)
        {

            // Sceneを遷移してもBGMが消えないようにする
            DontDestroyOnLoad(this);

        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MultiPlay" || SceneManager.GetActiveScene().name == "Menu")
        {
            
        }
        else
        {
            Destroy(this.gameObject);
        }

        Debug.Log("name" + SceneManager.GetActiveScene().name);
    }
}
