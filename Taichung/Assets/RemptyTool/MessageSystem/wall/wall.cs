using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
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
        if (ds > 12 && ds < 13) { gameManager.inhouse = 2; } 
        if (ds < 0.5243022F && animator.transform.localScale.y < 0.5550001F && gameManager.inside != 1) { gameManager.stop = 1; }
        else if (ds < 0.6264917F && gameManager.inside == 1) { gameManager.stop = 2; }
       // else{ gameManager.stop = 0; }
    }
}
//0.4920323