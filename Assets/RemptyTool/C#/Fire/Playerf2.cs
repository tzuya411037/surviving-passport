using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Playerf2 : MonoBehaviour
{
    // Init
    float moveSpeed = 0.1f;
    public joyStickf2 jsMovement;
    public Vector3 direction;
    public SpriteRenderer playerSr;
    public Animator playerAni;
    public bool crawl = false;
    

    void FixedUpdate()
    {
        // InputDirection can be used as per the need of your project
        direction = jsMovement.InputDirection;

        // If we drag the Joystick
        if (direction.magnitude != 0)
        {
            transform.position += direction * moveSpeed;
        }
        
        //animation
        if (direction.x < 0 && direction.y < 0.4 && direction.y > -0.4)
        {
            playerSr.flipY = false;
            playerSr.flipX = (crawl?false:true);
            playerAni.SetInteger("Status", (crawl?71:1));
        }
        else if (direction.x > 0 && direction.y < 0.4 && direction.y > -0.4)
        {
            playerSr.flipY = false;
            playerSr.flipX = (crawl?true:false);
            playerAni.SetInteger("Status", (crawl?71:1));
        }
        else if (direction.y > 0.4)
        {
            if(crawl){
                playerSr.flipY = false;
                playerAni.SetInteger("Status", 73);
            }
            else{
                playerAni.SetInteger("Status", 3);
            }
        }

        else if (direction.y < -0.4)
        {
            if(crawl){
                playerSr.flipY = true;
                playerAni.SetInteger("Status", 73);
            }
            else{
                playerAni.SetInteger("Status", 2);
            }
        }
        else if (playerAni.GetInteger("Status") == 2){ playerAni.SetInteger("Status", 0); }
        else if (playerAni.GetInteger("Status") == 3) { playerAni.SetInteger("Status", 5); }
        else if (playerAni.GetInteger("Status") == 1) { playerAni.SetInteger("Status", 4); }
        else if (playerAni.GetInteger("Status") == 73) { playerAni.SetInteger("Status", 74); }
        else if (playerAni.GetInteger("Status") == 71) { playerAni.SetInteger("Status", 72); }

        if(direction.x==0 && direction.y==0)
        {//靜止狀態下改爬行與否
            if(crawl)
            {//站立改爬行
                if(playerAni.GetInteger("Status")==0)
                {//down
                    playerSr.flipY = true;
                    playerAni.SetInteger("Status", 74);
                }
                else if(playerAni.GetInteger("Status")==5)
                {//up
                    playerSr.flipY = false;
                    playerAni.SetInteger("Status", 74);
                }
                else if(playerAni.GetInteger("Status")==4)
                {//right & left
                    playerSr.flipX = !playerSr.flipX;
                    playerAni.SetInteger("Status", 72);
                }
            }
            else
            {//爬行改站立
                if(playerAni.GetInteger("Status")==74)
                {//up & down
                    playerAni.SetInteger("Status",(playerSr.flipY?0:5));
                    playerSr.flipY = false;
                }
                else if(playerAni.GetInteger("Status")==72)
                {//right & left
                    playerSr.flipX = !playerSr.flipX;
                    playerAni.SetInteger("Status", 4);
                }
            }
        }
    }
}