﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            audioSource.PlayOneShot(buttonSe);
            Invoke("ChangeScene", 0.5f);
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
