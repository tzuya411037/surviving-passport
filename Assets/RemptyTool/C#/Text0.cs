using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Text0 : MonoBehaviour
{


    public GameObject Text02;


    GM gameManager;
    GM2 gameManager2;
    GM3 gameManager3;
    GM4 gameManager4;
    gameManagerf2 gameManager5;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GM>();
        gameManager2 = FindObjectOfType<GM2>();
        gameManager3 = FindObjectOfType<GM3>();
        gameManager4 = FindObjectOfType<GM4>();
        gameManager5 = FindObjectOfType<gameManagerf2>();
    }
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.clear > 0) { Text02.SetActive(true); }
        else { Text02.SetActive(false); }

        if(gameManager5!=null){
            if(gameManager.clear>0 && gameManager2.clear>0 && gameManager3.clear>0 && gameManager4.clear>0 && gameManager5.clear>0){
                SceneManager.LoadScene("StartE");
            }
        }
    }

}