using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stwitch : MonoBehaviour
{
    private Transform myTransform;
    public Transform playerTransform;
    public SpriteRenderer light;
    public float ds;
    public AudioSource audio;
    public AudioClip Turn;
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
        if (gameManager.pushed == 1)
        {
            if (ds < 1.5)
            {
                audio.PlayOneShot(Turn, 0.7F);
                gameManager.x++;
            }
        }
        if (gameManager.x % 2 == 0) { gameManager.Light = 1; light.flipY = true; }
        else { gameManager.Light = 0; light.flipY = false; }
        Debug.Log(gameManager.x);

    }

}
