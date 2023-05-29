using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WM : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator wsAni;
    public AudioSource audio;
    public AudioClip wash;
    GM3 gameManager;
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
        if (gameManager.wash == 1) { wsAni.SetInteger("cloth", 1); }
        else if (gameManager.wash == 2) { wsAni.SetInteger("cloth", 2); gameManager.hold = 0; }
        else if (gameManager.wash == 3) { wsAni.SetInteger("cloth", 3); 
        if (gameManager.playone == 0)
            {
                audio.loop = true;
                audio.PlayOneShot(wash, 1);
                gameManager.playone = 1;
            } 
        }
        else { wsAni.SetInteger("cloth", 0); audio.loop = false; audio.Stop(); }
    }
}