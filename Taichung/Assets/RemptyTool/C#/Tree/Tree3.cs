using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree3 : MonoBehaviour
{
    private Transform treeTransform;
    public Transform playerTransform;
    public Transform ThunderTransform;
    public Animator animator;
    public SpriteRenderer playerSr;
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
        if (GameObject.Find("Thunder") != null)
        {
            ThunderTransform = GameObject.Find("Thunder").transform;
        }
        treeTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        ds = Vector3.Distance(treeTransform.position, playerTransform.position);
        if (ds < 4) { gameManager.tree3 = ds; ThunderTransform.position = treeTransform.position; }
        if (gameManager.tree3 < 2 && gameManager.tree3 != 0) { gameManager.Tooclose3 = 1; } 
        else { gameManager.Tooclose3 = 0; }

        if (gameManager.tree3 != 0 && gameManager.tree3 < 1.5 && animator.transform.localScale.y > 0.55F && animator.transform.localScale.y < 0.7F) { gameManager.stop = 3; }
         else if (gameManager.tree3 != 0 && gameManager.tree3 < 1.5 && animator.transform.localScale.y < 0.74F && animator.transform.localScale.y > 0.7F) { gameManager.stop = 4; } else { gameManager.stop = 0; }


        // Debug.Log(gameManager.ds2);
    }
}

