using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class diang2 : MonoBehaviour
{
    GM3 gameManager;
    public GameObject count;
  //  public AudioSource audio;
   // public AudioClip hit;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GM3>();
    }
    void Start()
    {
       // audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        gameManager.diang = 2;
        count.SetActive(false);
       // gameManager.chance += 1;
       // audio.PlayOneShot(hit, 0.7F);
        if (gameManager.green == 1)
        {
            SceneManager.LoadScene("Livingroomx3-4");
        }
        else { SceneManager.LoadScene("Livingroom3-4"); }

    }
}