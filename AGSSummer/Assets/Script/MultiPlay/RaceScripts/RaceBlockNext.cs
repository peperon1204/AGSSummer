using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceBlockNext : MonoBehaviour
{
    private RaceBlockNext raceBlockNext;

    // Start is called before the first frame update
    void Start()
    {
        //rb2.bodyType = RigidbodyType2D.Dynamic;

        transform.Translate(3.0f, 3.0f, 0.0f);

        //raceCreateScript.Create();

        raceBlockNext.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
