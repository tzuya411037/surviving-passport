using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Down : MonoBehaviour
{
    public Transform playerTransform;
    public Animator playerAni;

    private float time;
    private int reload;
    private int ThunderTime;
    public Animator animator;

    GM gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GM>();
    }
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    public void OnClick()
    {
        reload = ThunderTime;
        if (playerAni.GetInteger("Status") == 0 || playerAni.GetInteger("Status") == 8 || playerAni.GetInteger("Status") == 7)
            {
                gameManager.Down = 1;
                playerAni.SetInteger("Status", 2);
            }

    }
    void Update()
    {
        time += Time.deltaTime;
        ThunderTime = (int)time;
        if (playerAni.GetInteger("Status") == 2 && ThunderTime - reload > 1.5f && animator.GetCurrentAnimatorStateInfo(0).IsName("thunder") == false)
        {
            playerAni.SetInteger("Status", 0);
        }
    }
}
