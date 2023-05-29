using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water2 : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform myTransform;
    public Transform playerTransform;
    public AudioSource audio;
    public AudioClip water;
    public float ds;
    public Animator animator;
    GM gameManager;

    private float time = 0;
    private float deltaTime;
    void Awake()
    {
        gameManager = FindObjectOfType<GM>();
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
        if (GameObject.Find("Player") != null)
        {
            playerTransform = GameObject.Find("Player").transform;
        }
        myTransform = this.transform;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        ds = Vector3.Distance(myTransform.position, playerTransform.position);

        deltaTime += Time.deltaTime;
        int ThunderTime = (int)deltaTime;
        Debug.Log(ThunderTime);
        if (ds < 4.21 && animator.transform.localScale.y < 0.68f)
        {
            gameManager.water = 1;
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Buck")
             || animator.GetCurrentAnimatorStateInfo(0).IsName("front")
             || animator.GetCurrentAnimatorStateInfo(0).IsName("walk")
             || animator.GetCurrentAnimatorStateInfo(0).IsName("running")
             )
            {
                if (deltaTime > 0.5)
                {
                    audio.PlayOneShot(water, 0.7F);
                    deltaTime = 0;
                }
            }
            else { audio.Stop(); }
        }

        else if (ds < 10) { audio.Stop(); gameManager.water = 0; }
    }
}
