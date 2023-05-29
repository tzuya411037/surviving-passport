using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Text0 : MonoBehaviour
{


    public GameObject Text01;


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

        Text01.SetActive(false);


        if (gameManager.clear > 0) { Text01.SetActive(true); }

    }

}