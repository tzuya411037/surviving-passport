using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p3 : MonoBehaviour
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
        pAni.SetInteger("place", 2);
        gameManager.place = 3;
    }
}