using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startwin : MonoBehaviour
{
    public Animator WinAni;
    // Start is called before the first frame update
    GM2 gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GM2>();
    }
    void Start()
    {
  

    }


    // Update is called once per frame
    void Update()
    {
        WinAni.SetInteger("Op", 0);
    }
}
