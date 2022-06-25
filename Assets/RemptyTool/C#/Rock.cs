using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private Transform treeTransform;
    public Transform playerTransform;
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
        treeTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        ds = Vector3.Distance(treeTransform.position, playerTransform.position);
        if (ds < 1.8) { gameManager.fall = 1; }
        else { gameManager.fall = 0;}
        Debug.Log(ds);
    }
}