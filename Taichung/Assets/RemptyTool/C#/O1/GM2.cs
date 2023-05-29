using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM2 : MonoBehaviour
{
    //singleton
    //單例模式
    static GM2 instance;
    public int chance,Light,x, hanging,open,y,z,putdown,dietime,safe,w,gasound,stright,bend,choose,p,place,check,pushed;
    public float ds;
    
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
            stright = 0;
            bend = 0;
            choose = 0;
            gasound = 0;
            hanging = 0;
            open = 0;
            putdown = 0;
            safe = 8;
            p = 0;
            place = 0;
            check = 0;
            ds = 0;
            pushed = 0;
            

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
        if (safe < 7 && chance < 12)
        {
            dietime = (int)deltaTime;
            Debug.Log(dietime);

            if (dietime == 5) { chance++; audio.PlayOneShot(hit, 0.7F); deltaTime = 0; }
        }
        else { deltaTime = 0; dietime = 0; audio.Stop(); }
    }
}
