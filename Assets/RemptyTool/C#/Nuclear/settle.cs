using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class settle : MonoBehaviour
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
        if (ds < 4 && gameManager.pushed == 1)
        {
            if (gameManager.water == 0 || gameManager.diang == 0 && gameManager.aspi == 0 || gameManager.green == 0 || gameManager.window < 2 || gameManager.wash == 0 && gameManager.fullbag == 0)
            {
                gameManager.chance += 35;
            }
            else { SceneManager.LoadScene("Gameclear"); }
        }



    }

}
