using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBlockMgr : MonoBehaviour
{
    private Rigidbody2D rb2;




    private GameObject createObject;
    private TitleBlock createScript;


    public GameObject blockEffect;      //ブロック破壊時のエフェクト


    AudioSource audioSource;


    //private Transform chilledObject;

    //private Transform child;

    // Start is called before the first frame update
    void Start()
    {

       // audioSource = GetComponent<AudioSource>();

        rb2 = GetComponent<Rigidbody2D>();

        createObject = GameObject.Find("CreateBlock");
        createScript = createObject.GetComponent<TitleBlock>();

       
    }

    // Update is called once per frame
    void Update()
    {
        if (!createScript.blockCreate)
        {
            Destroy(this.gameObject);
           // Instantiate(blockEffect, this.transform.position, Quaternion.identity); //エフェクト生成
        }
    }
}