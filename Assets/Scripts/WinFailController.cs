﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinFailController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
            SceneManager.LoadScene("Menu");
    }
}
