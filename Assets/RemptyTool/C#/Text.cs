using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Text : MonoBehaviour
{

    private float time;
    public float ds;
    public Transform playerTransform;
    private Transform myTransform;
    public Animator animator;

    GM gameManager;
    // Start is called before the first frame update
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
        time += Time.deltaTime;
        int TextTime = (int)time;
        Debug.Log(TextTime);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("flash3") == false) { time = 0; }

        else if(TextTime>5){  animator.SetInteger("Flash", 0);  SceneManager.LoadScene("outside5(2)"); }
    }
}
