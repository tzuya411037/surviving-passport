using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class END4 : MonoBehaviour
{


    public GameObject Text01;

    private float time;
    public Animator animator;

    GM4 gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GM4>();
    }
    void Start()
    {

        gameManager.clear += 1;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int TextTime = (int)time;
        Debug.Log(TextTime);
        Text01.SetActive(true);
        gameManager.chance = 0;
        gameManager.Shaked = 0;
        gameManager.check = 0;
        gameManager.time = 0;
        gameManager.pushed = 0;
        gameManager.hide = 0;
        gameManager.corr = 0;
        gameManager.audio = 0;
        gameManager.finished = 0;
        gameManager.stop = 0;
        gameManager.rooms = 0;

        if (TextTime > 5) { animator.SetTrigger("Fade out"); }
        if (TextTime > 8) { SceneManager.LoadScene("Selection4"); }
    }

}
