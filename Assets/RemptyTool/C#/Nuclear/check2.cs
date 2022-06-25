using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check2 : MonoBehaviour
{
    private Transform pointTransform;
    public Transform playerTransform;
    // Start is called before the first frame update
    GM3 gameManager;
    public float ds, x;
    public GameObject check;
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
        pointTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        ds = Vector3.Distance(pointTransform.position, playerTransform.position);
        if (ds < 2)
        {
            gameManager.ds = ds;
            if (gameManager.ds < x && gameManager.ds != 0)
            {
                if (gameManager.green == 1 && gameManager.hold == 1 || gameManager.green == 0 || gameManager.wash == 2)
                {
                    gameManager.check = 1;
                    check.SetActive(true);
                }
                else
                {
                    gameManager.check = 0;
                    check.SetActive(false);
                }
            }
            else
            {
                gameManager.check = 0;
                check.SetActive(false);
            }
        }
        //Debug.Log(ds);
    }
}