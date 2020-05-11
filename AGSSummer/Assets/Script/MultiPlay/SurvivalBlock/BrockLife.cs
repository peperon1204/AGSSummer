using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BrockLife : MonoBehaviour
{
    private float hp = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Block")
        {
            Debug.Log("hit");
            //.powerBlock; でfloorDamageのpowerBlockの値をゲット
            hp -= collision.gameObject.GetComponent<FloorDamage>().powerBlock;
        }

        //体力が0以下になった時{}内の処理が行われる
        if (hp <= 0)
        {
            //Destroy(gameObject);  //ゲームオブジェクトが破壊される
            SceneManager.LoadScene(0);
        }
    }
}

