using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab2 : MonoBehaviour
{
    public Joystick joystick;
    public int velocidad;
    public Rigidbody2D rb;
    public bool ConFisicas;
    public SpriteRenderer playerSr;
    public Transform playerTransform;
    public Animator playerAni;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        Vector2 direction = Vector2.up * joystick.Vertical + Vector2.right * joystick.Horizontal;
        if (direction.x < 0 && direction.y < 0.4 && direction.y > -0.4)   //right
        {  
            playerSr.flipX = true;
            playerAni.SetInteger("Status", 1);
            gameObject.transform.Translate(new Vector2(direction.x, 0) * velocidad * Time.deltaTime);
        }
        else if (direction.x > 0 && direction.y < 0.4 && direction.y > -0.4)  //left
        {
            playerSr.flipX = false;
            playerAni.SetInteger("Status", 1);
            gameObject.transform.Translate(new Vector2(direction.x, 0) * velocidad * Time.deltaTime);
        }
        else if (direction.y > 0.4)  //top
        {
            playerAni.SetInteger("Status", 6);
            if (transform.localScale.y > 0.3474974f && transform.localScale.x > 0.3474974f)
            {
              transform.localScale += new Vector3(-0.0025F, -0.0025F, 0); 
            }
        }

        else if (direction.y < -0.4)   //bottom
        {
            playerAni.SetInteger("Status", 5);
            if (transform.localScale.y < 0.9475018f && transform.localScale.x < 0.9475018f)
            {
                transform.localScale += new Vector3(0.0025F, 0.0025F, 0); 

            }
        }
        else if (playerAni.GetInteger("Status") == 5) { playerAni.SetInteger("Status", 7); }
        else if (playerAni.GetInteger("Status") == 6) { playerAni.SetInteger("Status", 8); }
        else if (playerAni.GetInteger("Status") == 1) { playerAni.SetInteger("Status", 0); }
        Debug.Log(direction);
    }
}
