using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private Transform treeTransform;
    public Transform playerTransform;
    public Transform ThunderTransform;
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
        if (ds < 4) {gameManager.tree=ds; ThunderTransform.position = treeTransform.position; }
        if (gameManager.tree < 2.5 && gameManager.tree != 0 && animator.transform.localScale.y < 0.467F) { gameManager.Tooclose1 = 1; ThunderTransform.position = playerTransform.position; }
        else { gameManager.Tooclose1 = 0;
            ThunderTransform.position = playerTransform.position;
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("down"))
            {
                ThunderTransform.position += new Vector3(2, 0, 0);
            }
        }
       // Debug.Log(gameManager.ds2);
    }
}
