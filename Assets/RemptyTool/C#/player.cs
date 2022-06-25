using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class player : MonoBehaviour
{
    public float x = 0.1f;

    // Start is called before the first frame update

    public float speed;
    public float speed_x_constraint;
    public float speed_y_constraint;
    public SpriteRenderer playerSr;
    Rigidbody2D rigid2D;

    [Range(0, 0.5f)]
    public float distance;
    public Animator playerAni;
    public Transform playerTransform;
    public Animator animator;
    public Animator animator2;

    private float time;
    private int reload;

    GM gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GM>();
    }
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
        rigid2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool IsWalking = false;
        bool Isdowning = false;
        bool Isrunning = false;
        bool Isfronting = false;
        bool Isbacking = false;
        time += Time.deltaTime;
        int ThunderTime = (int)time;
        //Debug.Log(ThunderTime);
        if (Input.GetKey(KeyCode.RightArrow) && playerAni.GetCurrentAnimatorStateInfo(0).IsName("back") == false && playerAni.GetCurrentAnimatorStateInfo(0).IsName("down") == false && gameManager.fall != 1)
        {
           
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || animator.GetCurrentAnimatorStateInfo(0).IsName("thunder") || animator2.GetCurrentAnimatorStateInfo(0).IsName("level changer") || gameManager.choose == 1 || gameManager.after == 1 || gameManager.stop == 1 || gameManager.stop2 == 1 || gameManager.stop3 == 1 || gameManager.stop4 == 1)
            {
               
                IsWalking = false;
            }
            else
            {
                IsWalking = true;
                if (playerSr.flipX == true)
                {
                    playerSr.flipX = false;
                }
                rigid2D.AddForce(new Vector2(100 * speed, 0), ForceMode2D.Force);
            }

        }
        if (Input.GetKey(KeyCode.LeftArrow) && playerAni.GetCurrentAnimatorStateInfo(0).IsName("back") == false && playerAni.GetCurrentAnimatorStateInfo(0).IsName("down") == false && gameManager.fall != 1)
        {
        
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || animator.GetCurrentAnimatorStateInfo(0).IsName("thunder") || animator2.GetCurrentAnimatorStateInfo(0).IsName("level changer") || gameManager.choose == 1 || gameManager.after == 1 || gameManager.stop == 2 || gameManager.stop2 == 2 || gameManager.stop5 == 1)
            {
                
                IsWalking = false;
            }
            else
            {
                IsWalking = true;
                if (playerSr.flipX == false)
                {
                    playerSr.flipX = true;
                }
                rigid2D.AddForce(new Vector2(-100 * speed, 0), ForceMode2D.Force);
            }
        }
        if (Input.GetKey(KeyCode.LeftAlt) && animator2.GetCurrentAnimatorStateInfo(0).IsName("level changer") == false && gameManager.after != 1 && gameManager.fall != 1 || gameManager.hide == 1)
        {
             reload = ThunderTime;
             Isdowning = true;
           

        }
        if (Input.GetKey(KeyCode.DownArrow) && playerAni.GetCurrentAnimatorStateInfo(0).IsName("back") == false && playerAni.GetCurrentAnimatorStateInfo(0).IsName("down") == false && animator2.GetCurrentAnimatorStateInfo(0).IsName("level changer") == false && gameManager.after != 1 && gameManager.fall != 1)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || animator.GetCurrentAnimatorStateInfo(0).IsName("thunder") || animator2.GetCurrentAnimatorStateInfo(0).IsName("level changer") || gameManager.choose == 1 || gameManager.after == 1 || gameManager.inside == 1 || gameManager.stop == 3)
            {

                Isfronting = false;
            }
            else
            {   
                Isfronting = true;
                if (transform.localScale.y < 0.9475018f && transform.localScale.x < 0.9475018f)
                {
                    if (Input.GetKey(KeyCode.LeftShift)) { transform.localScale += new Vector3(0.005F, 0.005F, 0); }
                    else { transform.localScale += new Vector3(0.0025F, 0.0025F, 0); }
                      
                }
            }
            
        }
        if (Input.GetKey(KeyCode.UpArrow) && playerAni.GetCurrentAnimatorStateInfo(0).IsName("back") == false && playerAni.GetCurrentAnimatorStateInfo(0).IsName("down") == false && animator2.GetCurrentAnimatorStateInfo(0).IsName("level changer") == false && gameManager.after != 1 && gameManager.fall != 1)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || animator.GetCurrentAnimatorStateInfo(0).IsName("thunder") || animator2.GetCurrentAnimatorStateInfo(0).IsName("level changer") || gameManager.choose == 1 || gameManager.after == 1 || gameManager.inside == 1 || gameManager.stop == 4)
            {

                Isbacking = false;
            }
            else
            {
                Isbacking = true;
                if (transform.localScale.y > 0.3474974f && transform.localScale.x > 0.3474974f)
                {
                     if (Input.GetKey(KeyCode.LeftShift)) { transform.localScale += new Vector3(-0.005F, -0.005F, 0); }
                    else { transform.localScale += new Vector3(-0.0025F, -0.0025F, 0); }
                }
            }
        }
        
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightArrow) && animator2.GetCurrentAnimatorStateInfo(0).IsName("level changer") == false && gameManager.after != 1 && gameManager.fall != 1)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("thunder") || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow)) {
                Isrunning = false; 
            }
            else
            {
                Isrunning = true;
                if (gameManager.water == 1) { speed = 1; }
                else { speed = 2; }
            }

        }
        else {
            if (gameManager.water == 1) { speed = 0.5F; }
            else { speed = 1; }
        }
        if (gameManager.fall == 1) { IsWalking = false; }



        if (rigid2D.velocity.x > speed_x_constraint)
        {
            rigid2D.velocity = new Vector2(speed_x_constraint, rigid2D.velocity.y);
        }
        if (rigid2D.velocity.x < -speed_x_constraint)
        {
            rigid2D.velocity = new Vector2(-speed_x_constraint, rigid2D.velocity.y);
        }
        if (IsWalking)
        {
            if (playerAni.GetInteger("Status") == 0)
            {
                playerAni.SetInteger("Status", 1);
            }

        }
        else
        {
            if (playerAni.GetInteger("Status") == 1)
            {
                playerAni.SetInteger("Status", 0);
            }
        }
        if (Isfronting)
        {
            if (playerAni.GetInteger("Status") == 0 || playerAni.GetInteger("Status") == 7)
            {
                playerAni.SetInteger("Status", 5);
            }
            else if (playerAni.GetInteger("Status") == 10) {
                playerAni.SetInteger("Status", 0);
            }

        }
        else
        {
            if (playerAni.GetInteger("Status") == 7 && Input.GetKey(KeyCode.RightArrow) || playerAni.GetInteger("Status") == 7 && Input.GetKey(KeyCode.LeftArrow))
            {
                playerAni.SetInteger("Status", 0);
            }
            else if (playerAni.GetInteger("Status") == 7 && Input.GetKey(KeyCode.UpArrow))
            { playerAni.SetInteger("Status", 8); }
            else if (playerAni.GetInteger("Status") == 5)
            { playerAni.SetInteger("Status", 7); }

        }
        if (Isbacking)
        {
            if (playerAni.GetInteger("Status") == 0 || playerAni.GetInteger("Status") == 8)
            {
                playerAni.SetInteger("Status", 6);
            }
            else if (playerAni.GetInteger("Status") == 10)
            {
                playerAni.SetInteger("Status", 0);
            }

        }
        else
        {
            if (playerAni.GetInteger("Status") == 8 && Input.GetKey(KeyCode.RightArrow) || playerAni.GetInteger("Status") == 8 && Input.GetKey(KeyCode.LeftArrow))
            {
                playerAni.SetInteger("Status", 0);
            }
            else if ( playerAni.GetInteger("Status") == 8 && Input.GetKey(KeyCode.DownArrow))
            { playerAni.SetInteger("Status", 7); }
            else if (playerAni.GetInteger("Status") == 6)
            { playerAni.SetInteger("Status", 8); }
        }
        if (Isdowning)
        {
            
            if (playerAni.GetInteger("Status") == 0 || playerAni.GetInteger("Status") == 8 || playerAni.GetInteger("Status") == 7)
            {
                    gameManager.Down = 1;
                    playerAni.SetInteger("Status", 2);
            }

        }
        else
        {   
            if (playerAni.GetInteger("Status") == 2 && ThunderTime - reload > 1 && animator2.GetCurrentAnimatorStateInfo(0).IsName("level changer") == false && animator.GetCurrentAnimatorStateInfo(0).IsName("thunder")==false)
            {
                playerAni.SetInteger("Status", 0);
            }
            if (ThunderTime - reload > 2)
            {
                gameManager.Down = 0;
            }
        }
        if (Isrunning)
        {
            playerAni.SetInteger("Status", 10);
        }
        else {
            if (playerAni.GetInteger("Status") == 10 && Input.GetKey(KeyCode.DownArrow))
            {
                playerAni.SetInteger("Status", 5);
            }
            else if(playerAni.GetInteger("Status") == 10 && Input.GetKey(KeyCode.UpArrow))
            {
                playerAni.SetInteger("Status", 6);
            }
            else if (playerAni.GetInteger("Status") == 10)
            {
                playerAni.SetInteger("Status", 1);
            }
        }
        



    }
    

}
