using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Putdown : MonoBehaviour
{
    private Transform pointTransform;
    public Transform playerTransform;
    // Start is called before the first frame update
    GM2 gameManager;
    public float ds;
    public GameObject phone,press,space;
    void Awake()
    {
        gameManager = FindObjectOfType<GM2>();
    }
    void Start()
    {
        if (GameObject.Find("Player") != null)
        {
            playerTransform = GameObject.Find("Player").transform;
        }
        pointTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        ds = Vector3.Distance(pointTransform.position, playerTransform.position);
        if (ds < 0.2) { gameManager.putdown = 1;
            if (gameManager.call < 1)
            {
                phone.SetActive(true);
                press.SetActive(true);
            }
            if (gameManager.place > 0) {space.SetActive(true); }
        }
        else { gameManager.putdown = 0; }
      //  Debug.Log(ds);
    }
}