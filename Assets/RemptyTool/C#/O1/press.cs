using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class press : MonoBehaviour
{
    GM2 gameManager;
    public Animator playerAni;
    bool Ispushing = false;
    public AudioSource audio;
    public AudioClip hit;
    public UnityEngine.UI.Text counting;
    private float time;
    private float reload;
    private int PressTime;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GM2>();
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
        if (gameManager.stright == 1) { playerAni.SetInteger("Status", 14); }
        if (gameManager.bend == 1) { playerAni.SetInteger("Status", 15); }
    }

    // Update is called once per frame
    public void OnClick()
    {
        Debug.Log(reload);
        Ispushing = true;
        if (playerAni.GetInteger("Status") > 13 && gameManager.place > 0 && time-reload > 0.383)
        {
            reload = time;
            if (playerAni.GetInteger("Status") == 15 || gameManager.place != 3) {
                gameManager.numb++;
                counting.text = gameManager.numb.ToString();
                gameManager.chance += 3; audio.PlayOneShot(hit, 0.7F); }
            else { gameManager.numb++; counting.text = gameManager.numb.ToString(); if (gameManager.numb > 120) {gameManager.chance += 3; audio.PlayOneShot(hit, 0.7F); } }
            
        }
    }
    void Update()
    {
        time += Time.deltaTime;
      //  PressTime = (int)time;
        if (Ispushing)
        {
            if (gameManager.stright == 1 && gameManager.numb > 120 || gameManager.stright == 1 && gameManager.place !=3) { playerAni.SetInteger("Status", 17);}
            else
            {
                playerAni.SetInteger("Status", 16);
            }
            Ispushing = false;

        }
        else
        {
            if (gameManager.stright == 1 && playerAni.GetInteger("Status") == 16) { playerAni.SetInteger("Status", 14);}
            if (gameManager.stright == 1 && playerAni.GetInteger("Status") == 17) { playerAni.SetInteger("Status", 14);}
            if (gameManager.bend == 1 && playerAni.GetInteger("Status") == 16) { playerAni.SetInteger("Status", 15);}
        }
    }

}
