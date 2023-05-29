using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleep : MonoBehaviour
{
    private Transform pointTransform;
    public Transform playerTransform;
    // Start is called before the first frame update
    GM3 gameManager;
    public float ds, x;
    public GameObject check2;
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
        if (ds < 4)
        {
            gameManager.ds = ds;
            if (gameManager.ds < x && gameManager.ds != 0)
            {
                gameManager.sleep = 1;
                check2.SetActive(true);

            }
            else
            {
                gameManager.sleep = 0;
                check2.SetActive(false);
            }
        }
        //Debug.Log(ds);
    }
}