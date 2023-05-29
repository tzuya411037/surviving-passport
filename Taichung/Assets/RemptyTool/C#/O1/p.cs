using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p : MonoBehaviour
{
    GM2 gameManager;
    public Animator pAni;
    // Start is called before the first frame update
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
        if (Input.GetKey(KeyCode.RightArrow)){
            if (gameManager.p > 27) { gameManager.p = 0; } 
            else { gameManager.p++; }  
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (gameManager.p < 0) { gameManager.p = 27; }
            else { gameManager.p--; }
        }
        if (gameManager.p > 18) { pAni.SetInteger("place", 2); gameManager.place = 3; }
        if (gameManager.p > 9 && gameManager.p < 19) { pAni.SetInteger("place", 1); gameManager.place = 2; }
        if (gameManager.p < 10) { pAni.SetInteger("place", 0); gameManager.place = 1; }
    }
}
