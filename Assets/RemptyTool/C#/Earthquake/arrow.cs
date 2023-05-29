using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    GM4 gameManager;
    public GameObject arrows;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GM4>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.finished == 1) { arrows.SetActive(true); }
        else { arrows.SetActive(false); }
    }
}
