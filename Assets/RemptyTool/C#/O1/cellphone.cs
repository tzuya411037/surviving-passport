using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cellphone : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip Ring;
    public GameObject count;
    // Start is called before the first frame update
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
        count.SetActive(true);
    }
}
