using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class End : MonoBehaviour
{


    public GameObject Text01;

    private float time;
    public Animator animator;

    GM3 gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GM3>();
    }
    void Start()
    {

        gameManager.clear += 1;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int TextTime = (int)time;
        Debug.Log(TextTime);
        Text01.SetActive(true); 

        if (TextTime > 5) { animator.SetTrigger("Fade out"); }
        if (TextTime > 8) { SceneManager.LoadScene("New Scene"); }
    }

}
