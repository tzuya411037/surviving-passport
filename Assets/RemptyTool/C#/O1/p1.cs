using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class p1 : MonoBehaviour
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
        
    }
    public void OnClick()
    {
        pAni.SetInteger("place", 3);
        gameManager.place = 1;
    }
}