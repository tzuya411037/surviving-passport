using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class diang0 : MonoBehaviour
{
    GM3 gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GM3>();
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        SceneManager.LoadScene("diang");

    }
}