using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock2 : MonoBehaviour
{
 
    // Start is called before the first frame update
    GM gameManager;
    public float ds;
    public Animator playerAni;
    void Awake()
    {
        gameManager = FindObjectOfType<GM>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameManager.hide = 0;
        if (playerAni.GetInteger("Status") == 2) { playerAni.SetInteger("Status", 0); }
        gameManager.fall = 0;

    }
}