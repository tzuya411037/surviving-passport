using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class YES3 : MonoBehaviour
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
        Destroy(GameObject.Find("鞋子"));
        gameManager.choose = 0;
        gameManager.shoes = 1;
        gameManager.after = 9;
    }
    void Update()
    {

    }
  
}