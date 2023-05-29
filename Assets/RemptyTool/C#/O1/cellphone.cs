using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cellphone : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip Ring;
    GM2 gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GM2>();
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        audio.PlayOneShot(Ring, 0.7F);
        gameManager.call = 1;
    }
}
