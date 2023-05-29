using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree2 : MonoBehaviour
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
        if (ds < 4) { gameManager.tree2 = ds; ThunderTransform.position = treeTransform.position; }
        if (gameManager.tree2 < 2 && gameManager.tree2 != 0 && animator.transform.localScale.y > 0.76F) { gameManager.Tooclose2 = 1; }
        else { gameManager.Tooclose2 = 0; }
        // Debug.Log(gameManager.ds2);
    }
}
