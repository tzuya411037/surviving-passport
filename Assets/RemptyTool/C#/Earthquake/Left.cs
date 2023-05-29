using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{
    public GameObject choose1;
    public GameObject choose2;
    GM4 gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GM4>();
    }
    void Start()
    {
      
    }
    void Update()
    {
        
    }
    public void OnClick()
    {
        gameManager.chance = 12;
        choose1.SetActive(false);
        choose2.SetActive(false);

    }

}
