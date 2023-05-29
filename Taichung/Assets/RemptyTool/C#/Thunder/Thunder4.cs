using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Thunder4 : MonoBehaviour
{
    public Animator playAni;
    public AudioSource audio;
    public AudioClip OOO;
    public AudioClip pi;
    public AudioClip pipi;
    public AudioClip pipipi;
    public float Speed;
    private Transform myTransform;
    public Transform playerTransform;
    private SpriteRenderer spr;
    public SpriteRenderer playerSr;
    public Animator animator;
    public Animator animator2;
    public float ds;
    private int levelToLoad;

    private float time = 0;
    private float deltaTime;


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
        time += Time.deltaTime;

        ds = Vector3.Distance(myTransform.position, playerTransform.position);

        myTransform.position = playerTransform.position;

        deltaTime += Time.deltaTime;
        int ThunderTime = (int)deltaTime;
        Debug.Log(ThunderTime);

        if (ThunderTime == 9) { gameManager.ping = 1; }

        if (gameManager.Down == 1 && gameManager.ping == 0 && gameManager.water!=1)
        {
            
                myTransform.position += new Vector3(2, 0, 0);
          
        }
        if (gameManager.water == 1) {
      
            if (gameManager.Thunderonwater == 0) {
                deltaTime = 0;
                gameManager.Thunderonwater += 1;
            }
            
            else if (ThunderTime == 0)
            {
                audio.clip = pipipi; audio.Play();
                Isflashing = true;
            }
            else if (ThunderTime == 2)
            {
                audio.Stop();
                Isthundering = true;
                audio.PlayOneShot(OOO);
                deltaTime = 0;
                gameManager.chance += 1;
                FadeToLevel(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else {
            gameManager.Thunderonwater = 0;
            if (ThunderTime == 1) { audio.clip = pi; audio.Play(); }
            if (ThunderTime == 4) { audio.clip = pipi; audio.Play(); }
            if (ThunderTime == 7) { audio.clip = pipipi; audio.Play(); Isflashing = true; }

            if (ThunderTime > 9)
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Buck")
                 || animator.GetCurrentAnimatorStateInfo(0).IsName("front")
                 || animator.GetCurrentAnimatorStateInfo(0).IsName("wait")
                 || animator.GetCurrentAnimatorStateInfo(0).IsName("walk")
                 || animator.GetCurrentAnimatorStateInfo(0).IsName("running")
                 || animator.GetCurrentAnimatorStateInfo(0).IsName("front stop")
                 || animator.GetCurrentAnimatorStateInfo(0).IsName("back stop")
                 )
                {
                    audio.Stop();
                    Isthundering = true;
                    audio.PlayOneShot(OOO);
                    gameManager.chance += 1;
                    FadeToLevel(SceneManager.GetActiveScene().buildIndex);
                }
                else
                {
                    audio.Stop();
                    Isthundering = true;
                    audio.PlayOneShot(OOO);
                    gameManager.ping = 0;
                }
                deltaTime = 0;
            }
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
                Destroy(GameObject.Find("角色2"));
                gameManager.after = 0;
                gameManager.water = 0;
                gameManager.ping = 0;
                gameManager.Down = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                gameManager.ping = 0;
                gameManager.chance = 0;
                gameManager.Thunderonwater = 0;
                gameManager.Down = 0;
                gameManager.water = 0;
                SceneManager.LoadScene("New Scene");
            }
        


    }

}