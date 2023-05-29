using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class test : MonoBehaviour
{  
   public void ChangeScene(int i)
    {
        //DontDestroyOnLoad(this);
        SceneManager.LoadScene(i);
   }

}