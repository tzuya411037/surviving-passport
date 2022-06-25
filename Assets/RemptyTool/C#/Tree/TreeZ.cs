using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeZ : MonoBehaviour
{
    private Transform treeTransform;
    public Transform playerTransform;
    public Animator animator;
    public SpriteRenderer playerSr;
    // Start is called before the first frame update
    GM gameManager;
    public float ds2;
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

        treeTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        ds2 = Vector3.Distance(treeTransform.position, playerTransform.position);

        if (playerSr.flipX == false)
        {
            if (ds2 < 1 && animator.transform.localScale.y > 0.572F && animator.transform.localScale.y < 0.7399F)
            {
                gameManager.stop4 = 1;
            }
            else { gameManager.stop4 = 0; }
        }

        else { gameManager.stop4 = 0; }



        // Debug.Log(gameManager.ds2);
    }
}