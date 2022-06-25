using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Heart3 : MonoBehaviour
{

    int HeartNum = 12;



    //宣告愛心

    public GameObject Heart01, Heart02, Heart03, Heart04, Heart05, Heart06, Heart07, Heart08, Heart09, Heart10, Heart11, Heart12;
    private int levelToLoad;
    public Animator animator2;





    GM3 gameManager;
    // Start is called before the first frame update
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
        if (gameManager.chance == 1)
        {
            HeartNum = HeartNum - 1;
            Heart01.SetActive(false);
        }
        if (gameManager.chance == 2)
        {
            HeartNum = HeartNum - 1;
            Heart01.SetActive(false);
            Heart02.SetActive(false);
        }
        if (gameManager.chance == 3)
        {
            HeartNum = HeartNum - 1;
            Heart01.SetActive(false);
            Heart02.SetActive(false);
            Heart03.SetActive(false);
        }
        if (gameManager.chance == 4)
        {
            HeartNum = HeartNum - 1;
            Heart01.SetActive(false);
            Heart02.SetActive(false);
            Heart03.SetActive(false);
            Heart04.SetActive(false);
        }
        if (gameManager.chance == 5)
        {
            HeartNum = HeartNum - 1;
            Heart01.SetActive(false);
            Heart02.SetActive(false);
            Heart03.SetActive(false);
            Heart04.SetActive(false);
            Heart05.SetActive(false);
        }
        if (gameManager.chance == 6)
        {
            HeartNum = HeartNum - 1;
            Heart01.SetActive(false);
            Heart02.SetActive(false);
            Heart03.SetActive(false);
            Heart04.SetActive(false);
            Heart05.SetActive(false);
            Heart06.SetActive(false);
        }
        if (gameManager.chance == 7)
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
        if (gameManager.chance == 8)
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
        if (gameManager.chance == 9)
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
        if (gameManager.chance == 10)
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
        if (gameManager.chance == 11)
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
        if (gameManager.chance == 12)
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
        gameManager.Light = 0;
        gameManager.w = 0;
        gameManager.x = 0;
        gameManager.y = 0;
        gameManager.z = 0;
        gameManager.gasound = 0;
        gameManager.hanging = 0;
        gameManager.open = 0;
        gameManager.safe = 8;
        SceneManager.LoadScene("New Scene");
    }



}
