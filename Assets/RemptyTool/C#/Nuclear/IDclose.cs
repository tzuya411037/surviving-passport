﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IDclose : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject IDcard;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        IDcard.SetActive(false);

    }
}