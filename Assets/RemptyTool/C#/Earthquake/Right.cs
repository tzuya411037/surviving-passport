using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Right : MonoBehaviour
{
    public GameObject choose1;
    public GameObject choose2;
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

    }
    public void OnClick()
    {
        choose1.SetActive(false);
        choose2.SetActive(false);
        SceneManager.LoadScene("earthquakeGameclear");
       

    }

}
