using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IDopen : MonoBehaviour
{
    // Start is called before the first frame update
    GM3 gameManager;
    public GameObject IDcard;
    public UnityEngine.UI.Text yearold;
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
        yearold.text = gameManager.year.ToString();
        IDcard.SetActive(true);

    }
}