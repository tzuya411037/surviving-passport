using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class random : MonoBehaviour
{
    GM4 gameManager;

    public void ChangeScene()
    {
        gameManager = FindObjectOfType<GM4>();
       // if(gameManager!=null){
       //     gameManager.clear = 0;
       // }
        SceneManager.LoadScene(Random.Range(48, 53));
    }

}