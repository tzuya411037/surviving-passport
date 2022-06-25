using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class washmachine : MonoBehaviour
{
    private Transform myTransform;
    public Transform playerTransform;
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
            if (ds < 2)
            {
                if (gameManager.hold == 1 && gameManager.cloth % 2 != 0)
                {
                    gameManager.wash = 2;
                }
                else if (gameManager.hold == 0 && gameManager.wash == 2) { audio.PlayOneShot(op, 1); gameManager.wash = 3; gameManager.fin++; gameManager.chance += 3; }
                else if (gameManager.wash < 3) { audio.PlayOneShot(op, 1); gameManager.cloth++; }
            }
        }
        if (gameManager.wash != 2 && gameManager.wash != 3)
        {
            if (gameManager.cloth % 2 == 0) { gameManager.wash = 0; }
            else { gameManager.wash = 1; }
        }


       // Debug.Log(ds);
    }
}