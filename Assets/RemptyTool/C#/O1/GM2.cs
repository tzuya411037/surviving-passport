using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM2 : MonoBehaviour
{
    //singleton
    //單例模式
    static GM2 instance;
    public int chance,Light,x, hanging,open,y,z,putdown,dietime,safe,w,gasound,stright,bend,choose,p,place,check,pushed,clear,call,bb,numb, babbletime, wait;
    public float ds, barrierds;
    
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
            numb = 0;
            x = 0;
            y = 0;
            z = 0;
            bb = 0;
            call = 0;
            clear = 0;
            stright = 0;
            bend = 0;
            choose = 0;
            gasound = 0;
            hanging = 0;
            open = 0;
            putdown = 0;
            p = 0;
            place = 0;
            check = 0;
            ds = 0;
            pushed = 0;
            barrierds = 0;
            babbletime = 0;
            wait = 0;



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
        if (safe < 8)
        {
            if (chance < 34 && time > 5)
            {
                dietime = (int)deltaTime;
                if (safe == 7)
                {
                    if (dietime == 4) { chance++; deltaTime = 0; audio.PlayOneShot(hit, 0.7F); }
                        //if (chance == 1 || chance == 4 || chance == 7 || chance == 10 || chance == 13 || chance == 16 || chance == 19 || chance == 22 || chance == 25|| chance == 31|| chance == 28|| chance >= 34) { audio.PlayOneShot(hit, 0.7F); }
                    }
                    else if (hanging == 1 && safe < 7)
                {
                    if (dietime == 1) { chance+=3;  deltaTime = 0; audio.PlayOneShot(hit, 0.7F); }
                }
                else
                {
                    if (dietime == 2) { chance++; deltaTime = 0; audio.PlayOneShot(hit, 0.7F); }
                }
            }
            else { deltaTime = 0; dietime = 0; audio.Stop(); }
        }
        else { time = 0; deltaTime = 0; dietime = 0; audio.Stop(); }
    }
}
