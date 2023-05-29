using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound2 : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip Turn;
    private float deltaTime;
    private int soundTime;
    GM3 gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GM3>();
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        soundTime = (int)deltaTime;

        if (soundTime > 7) //在時間過7秒後執行。
        {
            audio.Stop(); //先將可能正在播放中的音效停止。
            audio.PlayOneShot(Turn, 0.5F); //開始播放"警報聲"音效。
            deltaTime = 0; //因為播放的音檔本身就是持續10幾秒的音效，在開始播放後將時間歸零(未達if滿足條件)，使其保留在"播放一次及結束"的狀態。
        }
    }
}
