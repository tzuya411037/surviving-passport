using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layer : MonoBehaviour
{
    public int sortingOrder = 0;
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    GM gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GM>();
    }
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sortingOrder = sortingOrder;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.inside == 1 || gameManager.inside2 ==1) { sprite.sortingOrder = 4; }
        else if (gameManager.stop == 1 || gameManager.stop == 2 || gameManager.stop2 == 1 || gameManager.stop2 == 2) { sprite.sortingOrder = 2; }
        else { sprite.sortingOrder = 6; }
    }
}
