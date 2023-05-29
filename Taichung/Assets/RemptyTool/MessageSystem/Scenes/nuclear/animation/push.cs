using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class push : MonoBehaviour
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
        gameManager.pushed = 0;
    }
    public void OnClick()
    {
        gameManager.pushed = 1;

    }
}
