using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            this.transform.localScale = new Vector2(2, 2);
        }

    }
}
