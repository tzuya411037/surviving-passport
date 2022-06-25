using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainsound : MonoBehaviour
{
    private Transform myTransform;
    public Transform playerTransform;
    public AudioSource audio;
    public AudioClip rain;
    public float ds;
    public Animator animator;
    public int x;
    // Start is called before the first frame update
    void Start()
    {
    audio = GetComponent<AudioSource>();
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
        if (ds < 3 && x == 0) { audio.PlayOneShot(rain, 0.2F); audio.Play(); x = 1; }
  
    }
}
