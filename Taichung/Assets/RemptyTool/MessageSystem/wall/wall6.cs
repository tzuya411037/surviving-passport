using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall6 : MonoBehaviour
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
        if (ds2 < 0.6177286F && animator.transform.localScale.y < 0.545F && gameManager.inside2 != 1) { gameManager.stop2 = 2; }
        else if (ds2 < 0.5917009F && gameManager.inside2 == 1) { gameManager.stop2 = 1; }
        //else { gameManager.stop = 0; }
    }
}
