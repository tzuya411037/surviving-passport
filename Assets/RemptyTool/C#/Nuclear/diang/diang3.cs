﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class diang3 : MonoBehaviour
{
    GM3 gameManager;
    public GameObject count;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GM3>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        gameManager.diang = 3;
        count.SetActive(false);
        if (gameManager.green == 1)
        {
            SceneManager.LoadScene("Livingroomx3-4");
        }
        else { SceneManager.LoadScene("Livingroom3-4"); }

    }
}