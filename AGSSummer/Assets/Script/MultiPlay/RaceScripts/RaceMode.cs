using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RaceMode : MonoBehaviour
{
    public GameObject[] goalObject;

    private GoalLine[] goalLineScript;

    private GameObject getPlayerObject;

    private GetNumber getNumberScript;

    private int playerNumber;

    private bool[] stayTitle;

    // Start is called before the first frame update
    void Start()
    {
        getPlayerObject = GameObject.Find("GetPlayer");
        getNumberScript = getPlayerObject.GetComponent<GetNumber>();
        playerNumber = getNumberScript.Number;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Invoke("ChangeScene", 0.0f);
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Title");
    }
}
