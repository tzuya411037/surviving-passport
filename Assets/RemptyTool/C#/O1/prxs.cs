using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prxs : MonoBehaviour
{
    GM2 gameManager;
    public GameObject mm, straight, bend;
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
      
    }
    public void OnClick()
    {
        if (gameManager.call == 0)
        {
            gameManager.chance += 34;
        }
        else {
            straight.SetActive(true);
            bend.SetActive(true);
            Destroy(mm);
        }

    }
}
