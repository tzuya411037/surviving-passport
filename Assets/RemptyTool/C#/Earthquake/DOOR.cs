using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DOOR : MonoBehaviour
{

    [Header("連接到某場景")]
    public string goToTheScene;
    GM4 gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GM4>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager.finished == 1)
            {
                SceneManager.LoadScene(goToTheScene);
            }  
        }
    }

}
