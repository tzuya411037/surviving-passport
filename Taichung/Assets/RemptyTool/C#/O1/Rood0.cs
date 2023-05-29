using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rood0 : MonoBehaviour
{

    [Header("連接到某場景")]
    public string goToTheScene;
    GM2 gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GM2>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.safe = 0;
            SceneManager.LoadScene(goToTheScene);
        }
    }

}

