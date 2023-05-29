using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class O1SceneChange : MonoBehaviour
{
    GM2 gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GM2>();
    }
    public void ChangeScene(int i)
    {
      //  if(i==10){
      //  // 進O1
      //      gameManager.clear = 0;
      //  }
        gameManager.safe = 0;
        SceneManager.LoadScene(i);
    }
}
