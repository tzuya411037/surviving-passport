using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    //宣告愛心數量=3

    int HeartNum = 3;



    //宣告愛心01

    public GameObject Heart01;



    //宣告愛心02

    public GameObject Heart02;



    //宣告愛心03

    public GameObject Heart03;

    public GameObject b01;



    public GameObject b02;
    GM gameManager;
    // Start is called before the first frame update
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
        if (gameManager.chance == 1)
        {
            HeartNum = HeartNum - 1;
            Heart01.SetActive(false);
        }
        if (gameManager.chance == 2)
        {
            HeartNum = HeartNum - 1;
            Heart01.SetActive(false);
            Heart02.SetActive(false);
        }
        if (gameManager.chance == 3)
        {
            HeartNum = HeartNum - 1;
            Heart01.SetActive(false);
            Heart02.SetActive(false);
            Heart03.SetActive(false);
        }
        
        if (gameManager.choose == 1)
        {
            b01.SetActive(true);
            b02.SetActive(true);
        }
        else
        {
            b01.SetActive(false);
            b02.SetActive(false);
        }
    }
}
