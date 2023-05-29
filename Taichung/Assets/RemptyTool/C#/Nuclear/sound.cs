using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class sound : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip close;
    private float Timer;
    private int click = 0; //一個觸發條件(1是開啟、2是關閉)
    GM3 gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GM3>();
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
        Timer = audio.clip.length;

    }  
    // Update is called once per frame
    void Update()
    {
        Timer = Timer - Time.deltaTime;
        if (Timer < 9 && Timer > 8 && click !=2 ) { click = 1; } //當Timer在8和9之間(由於非整數)，且未觸發click時，開啟click。
        if (click == 1) { audio.Stop(); audio.PlayOneShot(close, 0.5F); click = 2; }  //當click為開啟時，播放音效，並把click關閉(只播放一次)。
        if (Timer <= 8) { Destroy(gameObject); SceneManager.LoadScene(18); } //當Timer大於等於8秒時，刪除物件(強行停止播放)並轉換至下一個場景。

    }
}
