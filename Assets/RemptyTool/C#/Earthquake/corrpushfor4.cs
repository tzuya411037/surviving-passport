using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class corrpushfor4 : MonoBehaviour
{
    GM4 gameManager;
    public GameObject hide;
    public SpriteRenderer one;
    public SpriteRenderer two;
    public SpriteRenderer three;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GM4>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameManager.pushed = 0;
    }
    public void OnClick()
    {
        gameManager.corr = 1;
        gameManager.hide = 1;
        gameManager.pushed = 1;
        gameManager.stop = 1;
        hide.SetActive(false);
        one.color = new Color32(255, 255, 255, 0);
        two.color = new Color32(255, 255, 255, 0);
        three.color = new Color32(255, 255, 255, 0);

    }
}
