using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NuclearScenechange : MonoBehaviour
{
    GM3 gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GM3>();
    }
    public void ChangeScene(int i)
    {
       // if(i==18){
       // //進核能
       //     gameManager.clear = 0;
       // }
        gameManager.safe = 0;
        SceneManager.LoadScene(i);
    }
}
