using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall5 : MonoBehaviour
{
    private Transform myTransform;
    public Transform playerTransform;
    public Animator animator;
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
        myTransform = this.transform;

    }

    // Update is called once per frame
    void Update()
    {
        ds2 = Vector3.Distance(myTransform.position, playerTransform.position);
        if (ds2>0 && ds2 < 1 && animator.transform.localScale.y < 0.545F) { gameManager.inside2 = 1; }
        else { gameManager.inside2 = 0; }
    }
}
