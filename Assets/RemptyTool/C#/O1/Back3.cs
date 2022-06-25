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

        SceneManager.LoadScene("New Scene");
    }
    void Update()
    {

    }
}