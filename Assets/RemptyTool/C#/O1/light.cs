using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator LightAni;
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
        if (gameManager.Light == 1) { LightAni.SetInteger("Turn", 1); }
        else { LightAni.SetInteger("Turn", 0); }
    }
}
