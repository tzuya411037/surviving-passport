using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class test : MonoBehaviour
{  
    GM gameManager;
   public void ChangeScene(int i){
        if(i==54)
        {//進火災
          GameObject gm5 = GameObject.Find("遊戲控制器");
          if(gm5!=null) Destroy(gm5);
          gm5 = GameObject.Find("遊戲控制器f2");
          if(gm5!=null) Destroy(gm5);
        }
        else if(i==2)
        {//進雷擊
          gameManager = FindObjectOfType<GM>();
        //  if(gameManager!=null){
        //      gameManager.clear = 0;
        //  }
        }
     SceneManager.LoadScene(i);
   }

}