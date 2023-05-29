using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Help : MonoBehaviour
{
    private Transform myTransform;
    public Transform playerTransform;
    public float ds;
    public Animator friendAni;
    // Start is called before the first frame update
    GM2 gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GM2>();
    }
    void Start()
    {
        if (GameObject.Find("Player") != null)
        {
            playerTransform = GameObject.Find("Player").transform;
        }
        myTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {

        ds = Vector3.Distance(myTransform.position, playerTransform.position);
        if (gameManager.pushed == 1)
        {
            if (ds < 1)
            {
                gameManager.hanging = 1;
            }
        }
         if (gameManager.hanging  == 1) { friendAni.SetInteger("Show", 1); }
            else { friendAni.SetInteger("Show", 0); }

    }

}