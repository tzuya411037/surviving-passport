using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bag : MonoBehaviour
{
    private Transform myTransform;
    public Transform playerTransform;
    public Animator ebAni;
    public AudioSource audio;
    public AudioClip op;
    // Start is called before the first frame update

    GM3 gameManager;
    public float ds;
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
        if (gameManager.pushed == 1)
        {
            if (ds < 1 && gameManager.hold == 1)
            {
                    gameManager.fullbag = 1;
                    gameManager.hold = 0;
                
            }
        }
        if (gameManager.fullbag == 1)
        {
            ebAni.SetInteger("Status", 1);
        }

        Debug.Log(ds);
    }
}