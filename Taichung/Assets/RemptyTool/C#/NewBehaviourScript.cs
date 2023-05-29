using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    //singleton
    //單例模式
    static GM instance;
    public int chance, choose, after,fall,time, shoes,clear,water, Thunderonwater,stop,stop2,stop3, stop4, stop5, inside, inside2, inhouse ,Down ,ping , Tooclose1, Tooclose2, Tooclose3 , hide;
    public float ds,ds2,tree,tree2,tree3;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            name = "最初的遊戲管理物件";
            chance = 0;
            ds = 0;
            ds2 = 0;
            choose = 0;
            after = 0;
            fall = 0;
            time = 0;
            shoes = 0;
            clear = 0;
            water = 0;
            hide = 0;
            stop = 0;
            stop2 = 0;
            stop3 = 0;
            stop4 = 0;
            stop5 = 0;
            inside = 0;
            inside2 = 0;
            inhouse = 0;
            Thunderonwater = 0;
            Down = 0;
            ping = 0;
            Tooclose1 = 0;
            Tooclose2 = 0;
            Tooclose3 = 0;
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
