using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Heart2 : MonoBehaviour
{

    int HeartNum = 34;



    //宣告愛心

    public GameObject Heart01, Heart02, Heart03, Heart04, Heart05, Heart06, Heart07, Heart08, Heart09, Heart10, Heart11, Heart12;
    private int levelToLoad;
    public Animator animator2;





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
        if (gameManager.chance == 1 || gameManager.chance == 2 || gameManager.chance == 3)
        {
            HeartNum = HeartNum - 1;
            Heart01.SetActive(false);
        }
        if (gameManager.chance == 4 || gameManager.chance == 5 || gameManager.chance == 6)
        {
            HeartNum = HeartNum - 1;
            Heart01.SetActive(false);
            Heart02.SetActive(false);
        }
        if (gameManager.chance == 7 || gameManager.chance == 8 || gameManager.chance == 9)
        {
            HeartNum = HeartNum - 1;
            Heart01.SetActive(false);
            Heart02.SetActive(false);
            Heart03.SetActive(false);
        }
        if (gameManager.chance == 10 || gameManager.chance == 11 || gameManager.chance == 12)
        {
            HeartNum = HeartNum - 1;
            Heart01.SetActive(false);
            Heart02.SetActive(false);
            Heart03.SetActive(false);
            Heart04.SetActive(false);
        }
        if (gameManager.chance == 13 || gameManager.chance == 14 || gameManager.chance == 15)
        {
            HeartNum = HeartNum - 1;
            Heart01.SetActive(false);
            Heart02.SetActive(false);
            Heart03.SetActive(false);
            Heart04.SetActive(false);
            Heart05.SetActive(false);
        }
        if (gameManager.chance == 16 || gameManager.chance == 17 || gameManager.chance == 18)
        {
            HeartNum = HeartNum - 1;
            Heart01.SetActive(false);
            Heart02.SetActive(false);
            Heart03.SetActive(false);
            Heart04.SetActive(false);
            Heart05.SetActive(false);
            Heart06.SetActive(false);
        }
        if (gameManager.chance == 19 || gameManager.chance == 20 || gameManager.chance == 21)
        {
            HeartNum = HeartNum - 1;
            Heart01.SetActive(false);
            Heart02.SetActive(false);
            Heart03.SetActive(false);
            Heart04.SetActive(false);
            Heart05.SetActive(false);
            Heart06.SetActive(false);
            Heart07.SetActive(false);
        }
        if (gameManager.chance == 22 || gameManager.chance == 23 || gameManager.chance == 24)
        {
            HeartNum = HeartNum - 1;
            Heart01.SetActive(false);
            Heart02.SetActive(false);
            Heart03.SetActive(false);
            Heart04.SetActive(false);
            Heart05.SetActive(false);
            Heart06.SetActive(false);
            Heart07.SetActive(false);
            Heart08.SetActive(false);
        }
        if (gameManager.chance == 25 || gameManager.chance == 26 || gameManager.chance == 27)
        {
            HeartNum = HeartNum - 1;
            Heart01.SetActive(false);
            Heart02.SetActive(false);
            Heart03.SetActive(false);
            Heart04.SetActive(false);
            Heart05.SetActive(false);
            Heart06.SetActive(false);
            Heart07.SetActive(false);
            Heart08.SetActive(false);
            Heart09.SetActive(false);
        }
        if (gameManager.chance == 28 || gameManager.chance == 29 || gameManager.chance == 30)
        {
            HeartNum = HeartNum - 1;
            Heart01.SetActive(false);
            Heart02.SetActive(false);
            Heart03.SetActive(false);
            Heart04.SetActive(false);
            Heart05.SetActive(false);
            Heart06.SetActive(false);
            Heart07.SetActive(false);
            Heart08.SetActive(false);
            Heart09.SetActive(false);
            Heart10.SetActive(false);
        }
        if (gameManager.chance == 31 || gameManager.chance == 32 || gameManager.chance == 33)
        {
            HeartNum = HeartNum - 1;
            Heart01.SetActive(false);
            Heart02.SetActive(false);
            Heart03.SetActive(false);
            Heart04.SetActive(false);
            Heart05.SetActive(false);
            Heart06.SetActive(false);
            Heart07.SetActive(false);
            Heart08.SetActive(false);
            Heart09.SetActive(false);
            Heart10.SetActive(false);
            Heart11.SetActive(false);
        }
        if (gameManager.chance >= 34)
        {
            HeartNum = HeartNum - 1;
            Heart01.SetActive(false);
            Heart02.SetActive(false);
            Heart03.SetActive(false);
            Heart04.SetActive(false);
            Heart05.SetActive(false);
            Heart06.SetActive(false);
            Heart07.SetActive(false);
            Heart08.SetActive(false);
            Heart09.SetActive(false);
            Heart10.SetActive(false);
            Heart11.SetActive(false);
            Heart12.SetActive(false);
            FadeToLevel(SceneManager.GetActiveScene().buildIndex);
        }


    }
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator2.SetTrigger("Fade out");
    }
    public void OnFadeComplete()
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
        gameManager.clear = 0;
        SceneManager.LoadScene("Selection3");
    }
 

    
}
