using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Back3n3 : MonoBehaviour
{
    GM3 gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GM3>();
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
        gameManager.open = 0;
        gameManager.safe = 8;
        gameManager.wash = 0;
        gameManager.stop = 0;
        gameManager.diang = 0;
        gameManager.water = 0;
        gameManager.check = 0;
        gameManager.checkmed = 0;
        gameManager.checkdrink = 0;
        gameManager.pushed = 0;
        gameManager.fin = 0;
        gameManager.wk = 0;
        gameManager.window = 0;
        gameManager.hanging = 0;
        gameManager.cloth = 0;
        gameManager.hold = 0;
        gameManager.playone = 0;
        gameManager.green = 0;
        gameManager.aspi = 0;
        gameManager.fullbag = 0;
        gameManager.babbletime = 0;

        SceneManager.LoadScene("New Scene");
    }
    void Update()
    {

    }
}