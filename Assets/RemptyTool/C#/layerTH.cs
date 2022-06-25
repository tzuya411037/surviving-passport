using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layerTH : MonoBehaviour
{
    public int sortingOrder = 0;
    public SpriteRenderer sprite;
    public Animator animator;
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
        if (gameManager.tree !=0 && gameManager.tree < 2 && animator.transform.localScale.y > 0.53F) { sprite.sortingOrder = 2; }
        else { sprite.sortingOrder = 7; }
    }
}
//< 0.5225 > 0.7