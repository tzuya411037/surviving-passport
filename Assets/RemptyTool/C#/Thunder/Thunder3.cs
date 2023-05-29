using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Thunder3 : MonoBehaviour
{
    public Animator playAni;
    public AudioSource audio;
    public AudioClip OOO;
    public float Speed;
    private Transform myTransform;
    public Transform playerTransform;
    private SpriteRenderer spr;
    public SpriteRenderer playerSr;
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


        if (ThunderTime > 2) {Isflashing = true; }

        if (ThunderTime > 4)
        {

            audio.Stop();
            Isthundering = true;
            audio.PlayOneShot(OOO);
            gameManager.chance += 1;
            FadeToLevel(SceneManager.GetActiveScene().buildIndex);
            deltaTime = 0;

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else
        {
            gameManager.chance = 0;
            SceneManager.LoadScene("Selection2");
        }
    }

}