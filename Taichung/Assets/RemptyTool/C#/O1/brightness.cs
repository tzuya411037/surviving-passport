using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brightness : MonoBehaviour
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
        if (gameManager.Light == 1) { LightAni.SetInteger("bright", 1); }
        else { LightAni.SetInteger("bright", 0); }
    }
}
