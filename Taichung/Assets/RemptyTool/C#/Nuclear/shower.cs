using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class shower : MonoBehaviour
{
    private Transform myTransform;
    public Transform playerTransform;
    public SpriteRenderer light;
    public float ds;
    public AudioSource audio;
    public AudioClip Turn;
    public Animator animator2;
    private float deltaTime;
    private int showerTime;
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
        deltaTime += Time.deltaTime;
        showerTime = (int)deltaTime;

        ds = Vector3.Distance(myTransform.position, playerTransform.position);
        if (ds < 1.8 && gameManager.check == 1)
        {
            if (gameManager.pushed == 1)
            {
               // deltaTime = 0;
                gameManager.stop = 1;
                gameManager.hold = 1;
               // audio.PlayOneShot(Turn, 0.5F);
                animator2.SetTrigger("Fade out");
                gameManager.stop = 0; 
                gameManager.green = 1;
                SceneManager.LoadScene("bathroom3-2");
            }
        }
       // else { deltaTime = 0; audio.Stop(); }
       // if (showerTime > 2) { gameManager.stop = 0; gameManager.green = 1; SceneManager.LoadScene("bathroom3-2"); }

    }

}
