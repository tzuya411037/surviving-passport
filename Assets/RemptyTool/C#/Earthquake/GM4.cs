using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM4 : MonoBehaviour
{
    //singleton
    //單例模式
    static GM4 instance;
    public int chance, time, clear, inside, hide, pushed, check, Shaked, audio, corr, stop, rooms, finished;
    public float ds, ds2,ds3, tree, tree2, tree3;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            name = "最初的遊戲管理物件";
            chance = 0;
            ds = 0;
            check=0;
            corr = 0;
            audio = 0;
            Shaked = 0;
            time = 0;
            clear = 0;
            hide = 0;
            inside = 0;
            pushed = 0;
            stop = 0;
            rooms = 0;
            finished = 0;
       
        }
        else if (this != instance)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            Debug.Log("刪除場景" + sceneName + "的" + name);
            Destroy(gameObject);
        }
    }

    void Update()
    {

    }
}
