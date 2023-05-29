using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class back4f : MonoBehaviour
{
    gameManager gameManager;
    gameManagerf2 gameManager2;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<gameManager>();
        gameManager2 = FindObjectOfType<gameManagerf2>();
    }
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    public void OnClick()
    {
        if(gameManager!=null) gameManager.HP = 0;
        if(gameManager2!=null) gameManager2.HP = 0;
        //Destroy(gameManager);
        //Destroy(gameManager2);
        SceneManager.LoadScene("Selection4");
    }
    void Update()
    {

    }
}