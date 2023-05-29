using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window3n1 : MonoBehaviour
{
    private Transform myTransform;
    public Transform playerTransform;
    public float ds;
    public AudioSource audio;
    public AudioClip open;
    public Animator WinAni;
    // Start is called before the first frame update
    GM3 gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GM3>();
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
        if (GameObject.Find("Player") != null)
        {
            playerTransform = GameObject.Find("Player").transform;
        }
        myTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {

        ds = Vector3.Distance(myTransform.position, playerTransform.position);
        if (ds < 1 && gameManager.pushed == 1)
        {
            audio.PlayOneShot(open, 0.7F);
                gameManager.y++;
                if (gameManager.y % 2 != 0 && gameManager.y != 0)
                {
                    gameManager.window++;
                }
                else { gameManager.window--; }
            
        }
        if (gameManager.y % 2 == 0) { gameManager.open = 1; WinAni.SetInteger("Op", 1); }
        else { gameManager.open = 0; WinAni.SetInteger("Op", 0); }
        Debug.Log(gameManager.y);

    }

}
