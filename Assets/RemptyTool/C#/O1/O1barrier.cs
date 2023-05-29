using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O1barrier : MonoBehaviour
{
    private Transform pointTransform;
    public Transform playerTransform;
    // Start is called before the first frame update
    GM2 gameManager;
    public float ds, x;
    public GameObject barrier, barrier2, barrier3, barrier4;
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
        pointTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        ds = Vector3.Distance(pointTransform.position, playerTransform.position);
        if (ds < 4)
        {
            gameManager.barrierds = ds;
            if (gameManager.barrierds < x && gameManager.barrierds != 0 && gameManager.hanging != 1 && gameManager.safe != 8)
            {
                barrier.SetActive(true);
                barrier2.SetActive(true);
                barrier3.SetActive(true);
                barrier4.SetActive(true);

            }
            else
            {
                barrier.SetActive(false);
                barrier2.SetActive(false);
                barrier3.SetActive(false);
                barrier4.SetActive(false);
            }
        }
        //Debug.Log(ds);
    }
}