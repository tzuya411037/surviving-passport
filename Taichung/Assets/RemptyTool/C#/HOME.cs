using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HOME : MonoBehaviour
{

    private float deltaTime;
    public string goToTheScene;
    GM gameManager;
 
    public Animator animator2;
    void Awake()
    {
        gameManager = FindObjectOfType<GM>();
    }
    void Update()
    {
        deltaTime += Time.deltaTime;
        int ThunderTime = (int)deltaTime;
        Debug.Log(ThunderTime);

        if (animator2.GetInteger("Flash") == 0) { deltaTime = 0; } //當動畫未觸發時，時間永遠設為零。
        if (animator2.GetInteger("Flash") == 2 && ThunderTime > 2) { gameManager.chance = 0; SceneManager.LoadScene("Ending"); } //在Fade out動畫觸發後，時間開始增加，在2秒後(約動畫播放時間)轉換至下個場景。
    }
     void OnTriggerEnter2D(Collider2D other)
      {

        if (other.CompareTag("Player"))       //當玩家到達特定地點時，執行以下程式。
        {   
            animator2.SetInteger("Flash", 2);  //觸發Fade out動畫。
        }

    }

}

