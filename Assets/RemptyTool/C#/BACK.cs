using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BACK : MonoBehaviour
{
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
        gameManager.chance = 0;
        gameManager.ds = 0;
        gameManager.ds2 = 0;
        gameManager.choose = 0;
        gameManager.after = 9;
        gameManager.fall = 0;
        gameManager.time = 0;
        gameManager.shoes = 0;
        SceneManager.LoadScene("New Scene"); 
    }
    void Update()
    {

    }
}