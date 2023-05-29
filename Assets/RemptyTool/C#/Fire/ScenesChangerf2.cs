using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesChangerf2 : MonoBehaviour
{
    public bool playerOut = false;
    void OnTriggerExit2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Player"){
            playerOut = false;
        }
    }
    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Player") {
            Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
            camera.enabled = false;
            Transform player = GameObject.Find("player").GetComponent<Transform>();
            if(SceneManager.GetActiveScene().name=="Firecorridor"){
                if(gameObject.name=="go0"){
                    SceneManager.LoadScene("Fireroom0");
                    playerOut = true;
                }
                else if(gameObject.name=="go1"){
                    player.position = new Vector3(16.24f,0.15f,0f);
                    SceneManager.LoadScene("Fireroom1");
                }
                else if(gameObject.name=="go2"){
                    player.position = new Vector3(13.43f,0.18f,0f);
                    SceneManager.LoadScene("Fireroom2");
                }
                else if(gameObject.name=="go3"){
                    player.position = new Vector3(7.44f,0.22f,0f);
                    SceneManager.LoadScene("Fireroom3");
                }
                else if(gameObject.name=="go4"){
                    player.position = new Vector3(4.56f,0.22f,0f);
                    SceneManager.LoadScene("Fireroom4");
                }
                else if(gameObject.name=="go5"){
                    player.position = new Vector3(5.86f,1.13f,0f);
                    SceneManager.LoadScene("Fireroom5");
                }
                else if(gameObject.name=="go6"){
                    player.position = new Vector3(5.88f,0.96f,0f);
                    SceneManager.LoadScene("Fireroom6");
                }
                else if(gameObject.name=="go7"){
                    player.position = new Vector3(5.88f,0.91f,0f);
                    SceneManager.LoadScene("Fireroom7");
                }
                else if(gameObject.name=="go8"){
                    player.position = new Vector3(5.88f,0.94f,0f);
                    SceneManager.LoadScene("Fireroom8");
                }
                else if(gameObject.name=="go9"){
                    player.position = new Vector3(4.45f,-3.69f,0f);
                    SceneManager.LoadScene("Fireroom9");
                }
                else if(gameObject.name=="go10"){
                    player.position = new Vector3(7.32f,-3.69f,0f);
                    SceneManager.LoadScene("Fireroom10");
                }
                else if(gameObject.name=="go11"){
                    player.position = new Vector3(13.36f,-3.69f,0f);
                    SceneManager.LoadScene("Fireroom11");
                }
                else if(gameObject.name=="go12"){
                    player.position = new Vector3(16.01f,-3.69f,0f);
                    SceneManager.LoadScene("Fireroom12");
                }
                else if(gameObject.name=="go13"){
                    player.position = new Vector3(14.57f,-3.69f,0f);
                    SceneManager.LoadScene("Fireroom13");
                }
                else if(gameObject.name=="go14"){
                    player.position = new Vector3(14.57f,-3.69f,0f);
                    SceneManager.LoadScene("Fireroom14");
                }
                else if(gameObject.name=="go15"){
                    player.position = new Vector3(14.61f,0.18f,0f);
                    SceneManager.LoadScene("Fireroom15");
                }
                else if(gameObject.name=="go16"){
                    player.position = new Vector3(14.61f,0.18f,0f);
                    SceneManager.LoadScene("Fireroom16");
                }
            }
            else{
                if(SceneManager.GetActiveScene().name=="Fireroom1")
                    player.position = new Vector3(-9.15f,-6.74f,0f);
                else if(SceneManager.GetActiveScene().name=="Fireroom2")
                    player.position = new Vector3(1.6f,-6.74f,0f);
                else if(SceneManager.GetActiveScene().name=="Fireroom3")
                    player.position = new Vector3(5f,-6.74f,0f);
                else if(SceneManager.GetActiveScene().name=="Fireroom4")
                    player.position = new Vector3(15.6f,-6.74f,0f);
                else if(SceneManager.GetActiveScene().name=="Fireroom5")
                    player.position = new Vector3(18.6f,-6.6f,0f);
                else if(SceneManager.GetActiveScene().name=="Fireroom6")
                    player.position = new Vector3(18.6f,-1.26f,0f);
                else if(SceneManager.GetActiveScene().name=="Fireroom7")
                    player.position = new Vector3(18.6f,4.14f,0f);
                else if(SceneManager.GetActiveScene().name=="Fireroom8")
                    player.position = new Vector3(18.6f,9.44f,0f);
                else if(SceneManager.GetActiveScene().name=="Fireroom9")
                    player.position = new Vector3(15.64f,10.28f,0f);
                else if(SceneManager.GetActiveScene().name=="Fireroom10")
                    player.position = new Vector3(5f,10.28f,0f);
                else if(SceneManager.GetActiveScene().name=="Fireroom11")
                    player.position = new Vector3(1.6f,10.28f,0f);
                else if(SceneManager.GetActiveScene().name=="Fireroom12")
                    player.position = new Vector3(-9.15f,10.28f,0f);
                else if(SceneManager.GetActiveScene().name=="Fireroom13")
                    player.position = new Vector3(1.53f,-4.48f,0f);
                else if(SceneManager.GetActiveScene().name=="Fireroom14")
                    player.position = new Vector3(13.15f,-4.48f,0f);
                else if(SceneManager.GetActiveScene().name=="Fireroom15")
                    player.position = new Vector3(13.15f,8.22f,0f);
                else if(SceneManager.GetActiveScene().name=="Fireroom16")
                    player.position = new Vector3(1.53f,8.22f,0f);
                SceneManager.LoadScene("Firecorridor");
            }
            camera.enabled = true;
        }
    }

}
