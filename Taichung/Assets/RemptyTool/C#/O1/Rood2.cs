using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rood2 : MonoBehaviour
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
            if (gameManager.hanging == 1 && gameManager.safe > 6)
            {
                gameManager.safe = 8;
                SceneManager.LoadScene(goToTheScene);
            }
        }
    }

}
