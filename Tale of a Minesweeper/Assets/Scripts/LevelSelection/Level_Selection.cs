﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Selection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Start_Level_1_1()
    {

        SceneManager.LoadScene("Level_1");

    }

    public void Test_Level()
    {

        SceneManager.LoadScene("Test_Level");

    }

}
