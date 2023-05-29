using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect : MonoBehaviour
{
    private Transform myTransform;
    public Transform playerTransform;
    public Animator animator;
    // Start is called before the first frame update
    GM gameManager;
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
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("thunder"))
        {
            gameManager.ds = 40;
            //Debug.Log(gameManager.ds);
        }
        else
        {
            gameManager.ds = Vector3.Distance(myTransform.position, playerTransform.position);
        }
    }
}
