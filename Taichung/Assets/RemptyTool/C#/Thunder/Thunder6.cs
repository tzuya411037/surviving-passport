using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Thunder6 : MonoBehaviour
{
    public Animator playAni;
    public AudioSource audio;
    public AudioClip OOO;
    public AudioClip pi;
    public AudioClip pipi;
    public AudioClip pipipi;
    public enum Face { Left, Right };
    public Face face;
    public float Speed;
    private Transform myTransform;
    public Transform playerTransform;
    private SpriteRenderer spr;
    public SpriteRenderer playerSr;
    public Animator animator;
    public Animator animator2;
    public float ds;
    private int levelToLoad;


    private float deltaTime;
    private int finish = 0;



    // Start is called before the first frame update
    GM gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GM>();
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
        spr = this.transform.GetComponent<SpriteRenderer>();

        if (GameObject.Find("Player") != null)
        {
            playerTransform = GameObject.Find("Player").transform;
        }
        myTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        bool Isthundering = false;
        bool Isflashing = false;

        ds = (int)gameManager.ds;

        myTransform.position = playerTransform.position;
        // Debug.Log(ds);
        deltaTime += Time.deltaTime;
        int ThunderTime = (int)deltaTime;
        Debug.Log(ThunderTime);

        if (ThunderTime == 10) { gameManager.time = 1; }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("down") && gameManager.shoes != 0)
        {
            myTransform.position += new Vector3(2, 0, 0);
        }
        if (ds > 15) { audio.Stop(); }
        if (ds < 15 && ds > 10 && ThunderTime > 0 && finish == 0 && gameManager.shoes != 1) { audio.clip = pi; audio.Play(); deltaTime = 0; }
        if (ds < 11 && ds > 5 && ThunderTime > 0 && finish == 0 && gameManager.shoes != 1) { audio.clip = pipi; audio.Play(); deltaTime = 0; }
        if (ds < 6 && ds > 4 && ThunderTime > 0 && finish == 0 && gameManager.shoes != 1) { audio.clip = pipipi; audio.Play(); deltaTime = 0; Isflashing = true; }


        if (ds < 5 && myTransform.position == playerTransform.position && ThunderTime > 1 && finish == 0  && gameManager.shoes != 1)
        {
            audio.Stop();
            finish = 1;
            gameManager.time = 0;
            Isthundering = true;
            audio.PlayOneShot(OOO);
            gameManager.chance += 1;
            FadeToLevel(SceneManager.GetActiveScene().buildIndex);

        }
        if (Isthundering)
        {
            if (playAni.GetInteger("property") == 0)
            {
                playAni.SetInteger("property", 1);
            }
        }
        else
        {
            if (playAni.GetInteger("property") == 1)
            {
                playAni.SetInteger("property", 0);
            }
        }

        if (Isflashing)
        {
            if (animator2.GetInteger("Flash") == 0)
            {
                animator2.SetInteger("Flash", 1);
            }
        }
        else
        {
            if (animator2.GetInteger("Flash") == 1)
            {
                animator2.SetInteger("Flash", 0);
            }
        }



        // void OnCollisionEnter2D(Collision2D collision)
        // {
        // if (ds < 20 && animator.GetCurrentAnimatorStateInfo(0).IsName("ATK"))
        // {
        //     hp -= 1;
        //     playAni.SetTrigger("GETHIT");
        //    audio.PlayOneShot(OOO);
        //     print(hp);
        //    }
    }
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator2.SetTrigger("Fade out");
    }
    public void OnFadeComplete()
    {

        if (gameManager.chance < 3)
        {
            gameManager.after = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            gameManager.chance = 0;
            SceneManager.LoadScene("New Scene");
        }
    }


}
