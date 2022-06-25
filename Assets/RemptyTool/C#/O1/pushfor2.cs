using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pushfor2 : MonoBehaviour
{
    GM2 gameManager;
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
        gameManager.pushed = 0;
    }
    public void OnClick()
    {
        gameManager.pushed = 1;

    }
}
