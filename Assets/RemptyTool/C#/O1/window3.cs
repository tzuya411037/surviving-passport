using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window3 : MonoBehaviour
{
    private Transform myTransform;
    public Transform playerTransform;
    public float ds;
    public AudioSource audio;
    public AudioClip open;
    public Animator WinAni;
    // Start is called before the first frame update
    GM2 gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GM2>();
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
        if (Input.GetMouseButtonDown(0))
        {
            if (ds < 0.5)
            {
                audio.PlayOneShot(open, 0.7F);
                gameManager.w++;
                if (gameManager.w % 2 != 0 && gameManager.w != 0)
                {
                    gameManager.safe++;
                }
                else { gameManager.safe--; }
            }
        }
        if (gameManager.w % 2 == 0) { gameManager.open = 0; WinAni.SetInteger("Op", 0); }
        else { gameManager.open = 1; WinAni.SetInteger("Op", 1); }
        Debug.Log(gameManager.z);

    }

}