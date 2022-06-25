using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bend : MonoBehaviour
{
    GM2 gameManager;
    public GameObject ww,inside;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GM2>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.choose == 1) { Destroy(ww); }
    }
    public void OnClick()
    {
        gameManager.bend = 1;
        gameManager.choose = 1;
        inside.SetActive(true);
    }
}