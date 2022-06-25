using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall3 : MonoBehaviour
{
    private Transform myTransform;
    public Transform playerTransform;
    public Animator animator;
    // Start is called before the first frame update
    GM gameManager;
    public float ds;

    void Awake()
    {
        gameManager = FindObjectOfType<GM>();
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
        if (ds < 0.35F && animator.transform.localScale.y < 0.5550001F && gameManager.inside != 1) { gameManager.stop = 2; }
        else if (ds < 0.5917009F && gameManager.inside == 1) { gameManager.stop = 1; }
        else{ gameManager.stop = 0; }
    }
}