using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Playerf1 : MonoBehaviour
{
    // Init
    float moveSpeed = 0.1f;
    public joyStickf2 jsMovement;
    public Vector3 direction;
    public SpriteRenderer playerSr;
    public Animator playerAni;
    public bool crawl = false;
    public bool towl = false;
    bool lastTowl = false;
    public bool stop = false;
    

    void FixedUpdate()
    {
        // InputDirection can be used as per the need of your project
        direction = jsMovement.InputDirection;

        if(stop){
            direction = Vector3.zero;
            stop = false;
        }

        // If we drag the Joystick
        if (direction.magnitude != 0)
        {
            transform.position += direction * moveSpeed;
        }
        
        //animation
        if(lastTowl!=towl){
            lastTowl = towl;
            if(playerAni.GetInteger("Status")==4){
                playerAni.SetInteger("Status", 75);
            }
            else if(playerAni.GetInteger("Status")==0){
                playerAni.SetInteger("Status", 78);
            }
            else if(playerAni.GetInteger("Status")==5){
                playerAni.SetInteger("Status", 80);
            }
        }
        if(lastTowl){
            if (direction.x < 0 && direction.y < 0.4 && direction.y > -0.4)
            {
                playerSr.flipY = false;
                playerSr.flipX = true;
                playerAni.SetInteger("Status", (crawl?81:76));
            }
            else if (direction.x > 0 && direction.y < 0.4 && direction.y > -0.4)
            {
                playerSr.flipY = false;
                playerSr.flipX = false;
                playerAni.SetInteger("Status", (crawl?81:76));
            }
            else if (direction.y > 0.4)
            {
                if(crawl){
                    playerSr.flipY = false;
                    playerAni.SetInteger("Status", 83);
                }
                else{
                    playerAni.SetInteger("Status", 79);
                }
            }

            else if (direction.y < -0.4)
            {
                if(crawl){
                    playerSr.flipY = true;
                    playerAni.SetInteger("Status", 83);
                }
                else{
                    playerAni.SetInteger("Status", 77);
                }
            }
            else if (playerAni.GetInteger("Status") == 76){ playerAni.SetInteger("Status", 75); }
            else if (playerAni.GetInteger("Status") == 77) { playerAni.SetInteger("Status", 78); }
            else if (playerAni.GetInteger("Status") == 79) { playerAni.SetInteger("Status", 80); }
            else if (playerAni.GetInteger("Status") == 81) { playerAni.SetInteger("Status", 82); }
            else if (playerAni.GetInteger("Status") == 83) { playerAni.SetInteger("Status", 84); }

            if(direction.x==0 && direction.y==0)
            {//靜止狀態下改爬行與否
                if(crawl)
                {//站立改爬行
                    if(playerAni.GetInteger("Status")==78)
                    {//down
                        playerSr.flipY = true;
                        playerAni.SetInteger("Status", 84);
                    }
                    else if(playerAni.GetInteger("Status")==80)
                    {//up
                        playerSr.flipY = false;
                        playerAni.SetInteger("Status", 84);
                    }
                    else if(playerAni.GetInteger("Status")==75)
                    {//right & left
                        playerAni.SetInteger("Status", 82);
                    }
                }
                else
                {//爬行改站立
                    if(playerAni.GetInteger("Status")==84)
                    {//up & down
                        playerAni.SetInteger("Status",(playerSr.flipY?78:80));
                        playerSr.flipY = false;
                    }
                    else if(playerAni.GetInteger("Status")==82)
                    {//right & left
                        playerAni.SetInteger("Status", 75);
                    }
                }
            }
        }
        else{
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
}