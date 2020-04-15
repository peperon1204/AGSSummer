using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallBlock : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        //生成時に落下しない処理
        rigidbody2d.bodyType = RigidbodyType2D.Kinematic;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || timeElapsed >= 5)
        {
            //落下する
            rigidbody2d.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
