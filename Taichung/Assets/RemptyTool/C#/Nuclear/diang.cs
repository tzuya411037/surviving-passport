using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class diang : MonoBehaviour
{
    private Transform myTransform;
    public Transform playerTransform;
    public SpriteRenderer player;
    public float ds;
    // Start is called before the first frame update
    GM3 gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GM3>();
    }
    void Start()
    {
       
        if (GameObject.Find("Player") != null)
        {
            playerTransform = GameObject.Find("Player").transform;
        }
        myTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {

        ds = Vector3.Distance(myTransform.position, playerTransform.position);
        if (ds < 1.5 && player.flipX == false && gameManager.pushed == 1 && gameManager.diang == 0)
            {
                SceneManager.LoadScene("choosc");
            }
        
      

    }

}
