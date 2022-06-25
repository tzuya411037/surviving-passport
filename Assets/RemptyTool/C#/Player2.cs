using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player2 : MonoBehaviour
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

    //public Animator animator;
    // public Animator animator2;
    GM2 gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GM2>();
    }
    void Start()
    {
        rigid2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool IsWalking = false;
        bool Isfronting = false;
        bool Isbacking = false;
        bool Isrunning = false;
        bool Ishanging = false;
        if (gameManager.hanging == 1)
        {
            if (Input.GetKey(KeyCode.RightArrow) && gameManager.chance != 12)
            {

                if (Input.GetKey(KeyCode.LeftArrow))
                {

                    Ishanging = false;

                }
                else
                {
                    Ishanging = true;
                    if (playerSr.flipX == true)
                    {
                        playerSr.flipX = false;
                    }
                    rigid2D.AddForce(new Vector2(100 * speed, 0), ForceMode2D.Force);
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow) && gameManager.chance != 12)
            {

                if (Input.GetKey(KeyCode.RightArrow))
                {

                    Ishanging = false;

                }
                else
                {
                    Ishanging = true;
                    if (playerSr.flipX == false)
                    {
                        playerSr.flipX = true;
                    }
                    rigid2D.AddForce(new Vector2(-100 * speed, 0), ForceMode2D.Force);
                }
            }
            if (Input.GetKey(KeyCode.UpArrow) && gameManager.chance != 12)
            {
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow))// || animator2.GetCurrentAnimatorStateInfo(0).IsName("level changer") 
                {

                    Ishanging = false;
                }
                else
                {
                    Ishanging = true;
 
                        rigid2D.AddForce(new Vector2(0, 100 * speed), ForceMode2D.Force);
                    
                }
            }
            if (Input.GetKey(KeyCode.DownArrow) && gameManager.chance != 12)
            {
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow))//|| animator2.GetCurrentAnimatorStateInfo(0).IsName("level changer")
                {
                    Ishanging = false;
                }
                else
                {
                    Ishanging = true;

                        rigid2D.AddForce(new Vector2(0, -100 * speed), ForceMode2D.Force);
                    
                }
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow) && gameManager.chance != 12)
            {

                if (Input.GetKey(KeyCode.LeftArrow))
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
            if (Input.GetKey(KeyCode.LeftArrow) && gameManager.chance != 12)
            {

                if (Input.GetKey(KeyCode.RightArrow))
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

            if (Input.GetKey(KeyCode.UpArrow) && gameManager.chance != 12)
            {
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow))// || animator2.GetCurrentAnimatorStateInfo(0).IsName("level changer") 
                {

                    Isbacking = false;
                }
                else
                {
                    Isbacking = true;
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        rigid2D.AddForce(new Vector2(0, 100 * speed * 2), ForceMode2D.Force);
                    }
                    else
                    {
                        rigid2D.AddForce(new Vector2(0, 100 * speed), ForceMode2D.Force);
                    }
                }
            }
            if (Input.GetKey(KeyCode.DownArrow) && gameManager.chance != 12)
            {
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow))//|| animator2.GetCurrentAnimatorStateInfo(0).IsName("level changer")
                {
                    Isfronting = false;
                }
                else
                {
                    Isfronting = true;
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        rigid2D.AddForce(new Vector2(0, -100 * speed * 2), ForceMode2D.Force);
                    }
                    else
                    {
                        rigid2D.AddForce(new Vector2(0, -100 * speed), ForceMode2D.Force);
                    }
                }
            }
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightArrow) && gameManager.chance != 12)
        {
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
            {
                Isrunning = false;
            }
            else
            {
                Isrunning = true;
                speed = 4;
            }

        }
        else { speed = 2; }
 
        if (rigid2D.velocity.x > speed_x_constraint)
        {
            rigid2D.velocity = new Vector2(speed_x_constraint, rigid2D.velocity.y);
        }
        if (rigid2D.velocity.x < -speed_x_constraint)
        {
            rigid2D.velocity = new Vector2(-speed_x_constraint, rigid2D.velocity.y);
        }
        if (rigid2D.velocity.y > speed_y_constraint)
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, speed_y_constraint);
        }
        if (rigid2D.velocity.y < -speed_y_constraint)
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, -speed_y_constraint);
        }
        if (IsWalking)
        {
            if (playerAni.GetInteger("Status") == 4)
            {
                playerAni.SetInteger("Status", 1);
            }

        }
        else
        {
            if (playerAni.GetInteger("Status") == 1)
            {
                playerAni.SetInteger("Status", 4);
            }
        }
     
        if (Isfronting)
        {
            if (playerAni.GetInteger("Status") == 4 || playerAni.GetInteger("Status") == 0)
            {
                playerAni.SetInteger("Status", 2);
            }
            else if (playerAni.GetInteger("Status") == 10)
            {
                playerAni.SetInteger("Status", 4);
            }

        }
        else
        {
            if (playerAni.GetInteger("Status") == 0 && Input.GetKey(KeyCode.RightArrow) || playerAni.GetInteger("Status") == 0 && Input.GetKey(KeyCode.LeftArrow))
            {
                playerAni.SetInteger("Status", 4);
            }
            else if (playerAni.GetInteger("Status") == 0 && Input.GetKey(KeyCode.UpArrow))
            { playerAni.SetInteger("Status", 5); }
            else if (playerAni.GetInteger("Status") == 2)
            { playerAni.SetInteger("Status", 0); }

        }
  
        if (Isbacking)
        {
            if (playerAni.GetInteger("Status") == 4 || playerAni.GetInteger("Status") == 5)
            {
                playerAni.SetInteger("Status", 3);
            }
            else if (playerAni.GetInteger("Status") == 10)
            {
                playerAni.SetInteger("Status", 4);
            }

        }
        else
        {
            if (playerAni.GetInteger("Status") == 5 && Input.GetKey(KeyCode.RightArrow) || playerAni.GetInteger("Status") == 5 && Input.GetKey(KeyCode.LeftArrow))
            {
                playerAni.SetInteger("Status", 4);
            }
            else if (playerAni.GetInteger("Status") == 5 && Input.GetKey(KeyCode.DownArrow))
            { playerAni.SetInteger("Status", 0); }
            else if (playerAni.GetInteger("Status") == 3)
            { playerAni.SetInteger("Status", 5); }
        }
        if (Isrunning)
        {
            playerAni.SetInteger("Status", 10);
        }
        else
        {
            if (playerAni.GetInteger("Status") == 10 && Input.GetKey(KeyCode.DownArrow))
            {
                playerAni.SetInteger("Status", 2);
            }
            else if (playerAni.GetInteger("Status") == 10 && Input.GetKey(KeyCode.UpArrow))
            {
                playerAni.SetInteger("Status", 3);
            }
            else if (playerAni.GetInteger("Status") == 10)
            {
                playerAni.SetInteger("Status", 1);
            }
        }
        if (Ishanging)
        {
            playerAni.SetInteger("Status", 11);
        }
        else { 
            if (playerAni.GetInteger("Status") == 11) { playerAni.SetInteger("Status", 12); }
        }
        
    }
}
