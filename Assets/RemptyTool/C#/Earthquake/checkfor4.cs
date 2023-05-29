using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkfor4 : MonoBehaviour
{
    private Transform pointTransform;
    public Transform playerTransform;
    public SpriteRenderer player;
    // Start is called before the first frame update
    GM4 gameManager;
    public float ds, x;
    public GameObject check4;
    void Awake()
    {
        gameManager = FindObjectOfType<GM4>();
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
        if (ds < 2.4)
        {
            gameManager.ds = ds;
            if (gameManager.ds < x && gameManager.ds != 0 && gameManager.Shaked != 1 && gameManager.stop !=1 && gameManager.finished != 1)
            {
                gameManager.check = 1;
                check4.SetActive(true);

            }
            else
            {
                gameManager.check = 0;
                check4.SetActive(false);
            }
        }
        if (gameManager.hide == 1) { player.color = new Color32(255, 255, 255, 0); }
        //Debug.Log(ds);
    }
}