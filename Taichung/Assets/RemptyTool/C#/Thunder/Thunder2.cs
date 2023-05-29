using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Thunder2 : MonoBehaviour
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
    public Transform treeTransform;
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

       
        Debug.Log(gameObject.layer);
        deltaTime += Time.deltaTime;
        int ThunderTime = (int)deltaTime;
        // Debug.Log(ThunderTime);
        
        if (ThunderTime == 2) { audio.clip = pi; audio.Play(); }
        if (ThunderTime == 3) { audio.clip = pipi; audio.Play(); }//6
        if (ThunderTime == 4) { audio.clip = pipipi; audio.Play(); Isflashing = true; }//9
  
        if (ThunderTime > 5)//11
        {
            if (gameManager.Tooclose1 == 1 || gameManager.Tooclose2 == 1 || gameManager.Tooclose3 == 1)
            {  

                audio.Stop();
                Isthundering = true;
                audio.PlayOneShot(OOO);
                deltaTime = 0;
                gameManager.chance += 1;
                gameManager.Tooclose1 = 0;
                gameManager.Tooclose2 = 0;
                gameManager.Tooclose3 = 0;
                FadeToLevel(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {  
                audio.Stop();
                deltaTime = 0;
                Isthundering = true;
                audio.PlayOneShot(OOO);
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
                gameManager.Tooclose1 = 0;
                gameManager.Tooclose2 = 0;
                gameManager.Tooclose3 = 0;
            gameManager.tree = 0;
            gameManager.tree2 = 0;
            gameManager.tree3 = 0;
            gameManager.stop = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                gameManager.Tooclose1 = 0;
                gameManager.Tooclose2 = 0;
                gameManager.Tooclose3 = 0;
            gameManager.tree = 0;
            gameManager.tree2 = 0;
            gameManager.tree3 = 0;
            gameManager.chance = 0;
            gameManager.stop = 0;
            SceneManager.LoadScene("New Scene");
            }
       

    }

}