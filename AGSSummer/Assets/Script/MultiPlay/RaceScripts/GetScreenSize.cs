using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScreenSize : MonoBehaviour
{
    // Start is called before the first frame update

    //最初に作った画面のwidth
    public float defaultWidth;
 
    //最初に作った画面のheight
    public float defaultHeight;
    
    private float defaultAspect;

    private float actualAspect;

    public Text textOne;

    void Start()
    {
        defaultAspect = defaultWidth / defaultHeight;

        actualAspect = (float)Screen.width / (float)Screen.height;

        Debug.Log("Screen Width : " + Screen.width);
        Debug.Log("Screen  height: " + Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
