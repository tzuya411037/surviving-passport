using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall2 : MonoBehaviour
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
        if (ds < 2.22035F && animator.transform.localScale.y < 0.3450004F) { gameManager.inside = 1; }
        else { gameManager.inside = 0; }
    }
}//0.5675001 大小