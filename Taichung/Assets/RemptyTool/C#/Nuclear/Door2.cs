using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door2 : MonoBehaviour
{

    [Header("連接到某場景")]
    public string goToTheScene;
    GM3 gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GM3>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.playone = 0;
            SceneManager.LoadScene(goToTheScene);
        }
    }

}
