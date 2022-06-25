using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brightness2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator LightAni;
    GM3 gameManager;
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
        if (gameManager.Light == 1) { LightAni.SetInteger("bright", 1); }
        else { LightAni.SetInteger("bright", 0); }
    }
}
