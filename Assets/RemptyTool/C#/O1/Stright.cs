using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stright : MonoBehaviour
{
    GM2 gameManager;
    public GameObject mm,inside;
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
        if (gameManager.choose == 1) { Destroy(mm); }
    }
    public void OnClick()
    {

            gameManager.stright = 1;
            gameManager.choose = 1;
            inside.SetActive(true);
       
    }
}
