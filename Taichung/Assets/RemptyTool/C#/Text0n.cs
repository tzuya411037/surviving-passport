using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Text0n : MonoBehaviour
{


    public GameObject Text01;


    GM3 gameManager;
    // Start is called before the first frame update
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

        Text01.SetActive(false);


        if (gameManager.clear > 0) { Text01.SetActive(true); }

    }

}