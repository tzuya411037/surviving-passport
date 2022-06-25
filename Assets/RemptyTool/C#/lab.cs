using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab : MonoBehaviour
{
    public Joystick joystick;
    public int velocidad;
    public Rigidbody2D rb;
    public bool ConFisicas;
    public SpriteRenderer playerSr;
    public Animator playerAni;

    // Start is called before the first frame update
    GM3 gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GM3>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        Vector2 direction = Vector2.up * joystick.Vertical + Vector2.right * joystick.Horizontal;
        if (gameManager.stop != 1)
        {
            if (direction.x < 0 && direction.y < 0.4 && direction.y > -0.4)
            {
                playerSr.flipX = true;
                playerAni.SetInteger("Status", 1);
                gameObject.transform.Translate(direction * velocidad * Time.deltaTime);
            }
            else if (direction.x > 0 && direction.y < 0.4 && direction.y > -0.4)
            {
                playerSr.flipX = false;
                playerAni.SetInteger("Status", 1);
                gameObject.transform.Translate(direction * velocidad * Time.deltaTime);
            }
            else if (direction.y > 0.4)
            {
                playerAni.SetInteger("Status", 3);
                gameObject.transform.Translate(direction * velocidad * Time.deltaTime);
            }

            else if (direction.y < -0.4)
            {
                playerAni.SetInteger("Status", 2);
                gameObject.transform.Translate(direction * velocidad * Time.deltaTime);
            }
            else if (playerAni.GetInteger("Status") == 2) { playerAni.SetInteger("Status", 0); }
            else if (playerAni.GetInteger("Status") == 3) { playerAni.SetInteger("Status", 5); }
            else { playerAni.SetInteger("Status", 4); }
            //Debug.Log(direction);
        }
    }
}
