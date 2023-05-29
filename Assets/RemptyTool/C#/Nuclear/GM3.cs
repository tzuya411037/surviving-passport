using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM3 : MonoBehaviour
{
    //singleton
    //單例模式
    static GM3 instance;
    public int chance, Light, x, hanging, open, y, z,  dietime, safe, w, gasound, choose , wash ,cloth ,hold,playone,window,fin,wk , check,checkmed,checkdrink,pushed , diang ,water,stop,green,sleep,aspi,fullbag,babbletime,clear,open2, wait,year;
    public float ds = 0, barrierds = 0;

    private float time = 0;
    private float deltaTime;

    public AudioSource audio;
    public AudioClip hit;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            name = "最初的遊戲管理物件";
            chance = 0;
            Light = 0;
            w = 0;
            x = 0;
            y = 0;
            z = 0;
            cloth = 0;
            hold = 0;
            choose = 0;
            gasound = 0;
            open = 0;
            open2 = 0;
            hanging = 0;
            wash = 0;
            playone = 0;
            window = 0;
            wk = 0;
            wait = 0;
            fin = 0;
            check = 0;
            checkmed = 0;
            checkdrink = 0;
            pushed = 0;
            diang = 0;
            water = 0;
            stop = 0;
            green = 0;
            sleep = 0;
            aspi = 0;
            fullbag = 0;
            babbletime = 0;
            clear = 0;
            year = 0;
 

        }
        else if (this != instance)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            Debug.Log("刪除場景" + sceneName + "的" + name);
            Destroy(gameObject);
        }
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        time += Time.deltaTime;
        deltaTime += Time.deltaTime;
        if (window == 3 && wk == 0) { fin++; wk = 1; }
        if(window < 3 && wk == 1) { fin--; wk = 0; }

        if (window < 2 && safe !=8)
        {
            if (chance < 34 && time > 5)
            {
                dietime = (int)deltaTime;
                if (dietime == 2) { chance+=2; audio.PlayOneShot(hit, 0.7F); deltaTime = 0; }

            }
            else { deltaTime = 0; dietime = 0; audio.Stop(); }
        }
        else { time = 0; deltaTime = 0; dietime = 0; audio.Stop(); }
    }
}

