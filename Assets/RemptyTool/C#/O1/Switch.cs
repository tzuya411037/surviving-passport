using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private Transform myTransform;
    public Transform playerTransform;
    public SpriteRenderer light;
    public float ds;
    public AudioSource audio;
    public AudioClip Turn;
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
                if (ds < 1.5)
                {
                  audio.PlayOneShot(Turn, 0.7F);
                  gameManager.x++;
                }
            }
            if (gameManager.x % 2 == 0) { gameManager.Light = 0; light.flipY = false; }
            else { gameManager.Light = 1; light.flipY = true; }
            Debug.Log(gameManager.x);
        
    } 
  
}
