using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class YES : MonoBehaviour
{
    public Animator animator2;
    private int levelToLoad;


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
        gameManager.choose = 0;
        gameManager.after = 1;
        FadeToLevel(SceneManager.GetActiveScene().buildIndex);
    }
    void Update()
    {

    }
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator2.SetTrigger("Fade out");
    }
    public void OnFadeComplete()
    {
        gameManager.chance = 0;
        SceneManager.LoadScene("animation1");
  
    }
}

