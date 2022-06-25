using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2 : MonoBehaviour
{
    private Transform myTransform;
    public Transform playerTransform;
    public SpriteRenderer light;
    public float ds;
    public AudioSource audio;
    public AudioClip Turn;
    public AudioClip boom;

    private float time = 0;
    private float deltaTime;
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
        time += Time.deltaTime;
        deltaTime += Time.deltaTime;
        int bombtime = (int)deltaTime;
        ds = Vector3.Distance(myTransform.position, playerTransform.position);
        if (gameManager.pushed == 1)
        {
            if (ds < 1.5)
            {
                audio.PlayOneShot(Turn, 0.7F);
                gameManager.x++;
            }
        }
        if (gameManager.x % 2 == 0) { gameManager.Light = 0; light.flipY = false; }
        else { gameManager.Light = 1; light.flipY = true;}

        if (gameManager.x == 0) { deltaTime = 0; }

        if (bombtime > 1) { audio.PlayOneShot(boom, 0.4F); deltaTime = 0; gameManager.chance = 12; }
        Debug.Log(gameManager.x);

    }

}