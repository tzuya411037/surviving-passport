using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class back4 : MonoBehaviour
{
    GM4 gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GM4>();
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
        gameManager.Shaked = 0;
        gameManager.check = 0;
        gameManager.time = 0;
        gameManager.pushed = 0;
        gameManager.hide = 0;
        gameManager.corr = 0;
        gameManager.audio = 0;
        gameManager.stop = 0;
        gameManager.finished = 0;
        gameManager.rooms = 0;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Selection4");
    }
    void Update()
    {

    }
}