using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesChanger : MonoBehaviour
{
    public bool playerOut = false;
    void OnTriggerExit2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Player")
            playerOut = false;
    }
    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Player") {
            Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
            camera.enabled = false;
            Transform player = GameObject.Find("player").GetComponent<Transform>();
            if(SceneManager.GetActiveScene().name=="FireslivingRoom"){
                if(gameObject.name=="livingGoParents"){
                    player.position = new Vector3(13.91f,1.21f,0f);
                    SceneManager.LoadScene("FiresparentsRoom");
                }
                else if(gameObject.name=="livingGoBath"){
                    player.position = new Vector3(8.77f,2.58f,0f);
                    SceneManager.LoadScene("FiresbathRoom");
                }
                else if(gameObject.name=="livingGoKichen"){
                    player.position = new Vector3(8.92f,-6.08f,0f);
                    SceneManager.LoadScene("Fireskichen");
                }
                else if(gameObject.name=="livingGoChildren"){
                    player.position = new Vector3(9.84f,-5.15f,0f);
                    SceneManager.LoadScene("FiresChildrensRoom");
                }
                else if(gameObject.name=="livingGoBed"){
                    player.position = new Vector3(12.26f,-6.19f,0f);
                    SceneManager.LoadScene("FiresbedRoom");
                }
                else if(gameObject.name=="livingGoStudy"){
                    player.position = new Vector3(8.15f,3f,0f);
                    SceneManager.LoadScene("FiresstudyRoom");
                }
                else if(gameObject.name=="livingGoOut"){
                    playerOut = true;
                    Debug.Log("player touch out");
                }
            }
            else{
                SceneManager.LoadScene("FireslivingRoom");
                if(SceneManager.GetActiveScene().name== "FiresparentsRoom")
                    player.position = new Vector3(2.62f,-5.08f,0f);
                else if(SceneManager.GetActiveScene().name== "FiresbathRoom")
                    player.position = new Vector3(7.01f,-6.3f,0f);
                else if(SceneManager.GetActiveScene().name== "Fireskichen")
                    player.position = new Vector3(9f,5.5f,0f);
                else if(SceneManager.GetActiveScene().name== "FireschildrensRoom")
                    player.position = new Vector3(1.97f,7.3f,0f);
                else if(SceneManager.GetActiveScene().name== "FiresstudyRoom")
                    player.position = new Vector3(-2.83f,3.2f,0f);
                else if(SceneManager.GetActiveScene().name== "FiresbedRoom")
                    player.position = new Vector3(-4.32f,4.83f,0f);
            }
            camera.enabled = true;
        }
    }

}
