using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    private Transform myTransform;
    public Transform playerTransform;
    public AudioSource audio;
    public AudioClip swi;
    public AudioClip un;
    // Start is called before the first frame update

    GM2 gameManager;
    public float ds;
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
        if (gameManager.gasound == 0)
        {
            audio.loop = true;
            audio.PlayOneShot(swi, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ds = Vector3.Distance(myTransform.position, playerTransform.position);
        if (gameManager.pushed == 1)
        {
            if (ds < 0.7 && gameManager.gasound == 0)
            {
                audio.loop = false;
                audio.Stop();
                audio.PlayOneShot(un, 1);
                gameManager.safe += 5; 
                gameManager.gasound = 1;
            }
        }
 

        Debug.Log(ds);
    }
}