using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkchoice : MonoBehaviour
{
    // Start is called before the first frame update
    GM2 gameManager;
    public GameObject check2;
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
        if (gameManager.place > 0)
        {
            check2.SetActive(true);

        }
        else
        {
            check2.SetActive(false);
        }
    }
    //Debug.Log(ds);
}
