using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorno : MonoBehaviour
{
    private Transform myTransform;
    public Transform playerTransform;
    // Start is called before the first frame update

    GM3 gameManager;
    public float ds;
    void Awake()
    {
        gameManager = FindObjectOfType<GM3>();
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

        if (ds < 1 && gameManager.window > 1)
            {
                gameManager.babbletime = 5;

            }
        

        Debug.Log(ds);
    }
}