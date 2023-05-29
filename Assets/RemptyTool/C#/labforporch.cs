using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class labforporch : MonoBehaviour
{
    public Joystick joystick;
    public int velocidad;
    public Rigidbody2D rb;
    public bool ConFisicas;
    public SpriteRenderer playerSr;
    public Transform playerTransform;
    public Animator playerAni;
    GM2 gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GM2>();
    }
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
        if (direction.x < -0.8 && direction.y < 0.4 && direction.y > -0.4 && gameManager.putdown != 1)   //right
        {
            playerSr.flipX = true;
            playerAni.SetInteger("Status", 11);
            gameObject.transform.Translate(new Vector2(direction.x, 0) * velocidad * Time.deltaTime);
        }
        else if (direction.x > 0.8 && direction.y < 0.4 && direction.y > -0.4 && gameManager.putdown != 1)  //left
        {
            playerSr.flipX = false;
            playerAni.SetInteger("Status", 11);
            gameObject.transform.Translate(new Vector2(direction.x, 0) * velocidad * Time.deltaTime);
        }

        else if (gameManager.stright == 1) { playerAni.SetInteger("Status", 14); }
        else if (gameManager.bend == 1) { playerAni.SetInteger("Status", 15); }
        else if (gameManager.putdown == 1) { playerAni.SetInteger("Status", 13); }
        else if (playerAni.GetInteger("Status") == 11) { playerAni.SetInteger("Status", 12); }
        Debug.Log(direction);
    }
}
