using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Back3 : MonoBehaviour
{
    GM2 gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GM2>();
    }
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    public void OnClick()
    {
        gameManager.chance = 0;
        gameManager.w = 0;
        gameManager.Light = 0;
        gameManager.x = 0;
        gameManager.y = 0;
        gameManager.z = 0;
        gameManager.hanging = 0;
        gameManager.open = 0;
        gameManager.putdown = 0;
        gameManager.safe = 8;
        gameManager.numb = 0;
        gameManager.bb = 0;
        gameManager.call = 0;
        gameManager.stright = 0;
        gameManager.bend = 0;
        gameManager.choose = 0;
        gameManager.gasound = 0;
        gameManager.p = 0;
        gameManager.place = 0;
        gameManager.check = 0;
        gameManager.ds = 0;
        gameManager.pushed = 0;
        gameManager.barrierds = 0;
        gameManager.babbletime = 0;
        gameManager.wait = 0;
        SceneManager.LoadScene("Selection3");
    }
    void Update()
    {

    }
}