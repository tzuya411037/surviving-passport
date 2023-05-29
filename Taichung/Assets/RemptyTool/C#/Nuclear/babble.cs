using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class babble : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    private float deltaTime;
    private int waitTime;
    public Animator babbleAni;
    GM3 gameManager;
    // Start is called before the first frame update
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
        deltaTime += Time.deltaTime;
        waitTime = (int)deltaTime;
        gameManager.babbletime = waitTime;

        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position  

        if (gameManager.babbletime > 3 && gameManager.green == 0)
        {
            babbleAni.SetInteger("Status", 1);
            if (gameManager.babbletime > 12) { deltaTime = 0; babbleAni.SetInteger("Status", 0); }
        }
    }
}
