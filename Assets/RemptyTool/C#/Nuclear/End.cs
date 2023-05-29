using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class End : MonoBehaviour
{


    public GameObject Text01;

    private float time;
    public Animator animator;

    GM3 gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GM3>();
    }
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Gameclear")
        {
            gameManager.clear += 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int TextTime = (int)time;
        Debug.Log(TextTime);
        Text01.SetActive(true);

        gameManager.chance = 0;
        gameManager.Light = 0;
        gameManager.w = 0;
        gameManager.x = 0;
        gameManager.y = 0;
        gameManager.z = 0;
        gameManager.gasound = 0;
        gameManager.hanging = 0;
        gameManager.open = 0;
        gameManager.safe = 8;
        gameManager.cloth = 0;
        gameManager.hold = 0;
        gameManager.choose = 0;
        gameManager.gasound = 0;
        gameManager.open = 0;
        gameManager.open2 = 0;
        gameManager.hanging = 0;
        gameManager.safe = 8;
        gameManager.wash = 0;
        gameManager.playone = 0;
        gameManager.window = 0;
        gameManager.wk = 0;
        gameManager.wait = 0;
        gameManager.fin = 0;
        gameManager.check = 0;
        gameManager.checkmed = 0;
        gameManager.checkdrink = 0;
        gameManager.pushed = 0;
        gameManager.diang = 0;
        gameManager.water = 0;
        gameManager.stop = 0;
        gameManager.green = 0;
        gameManager.sleep = 0;
        gameManager.aspi = 0;
        gameManager.fullbag = 0;
        gameManager.babbletime = 0;
        gameManager.year = 0;

        if (TextTime > 5) { animator.SetTrigger("Fade out"); }
        if (TextTime > 8) { SceneManager.LoadScene("Selection3"); }
    }

}
