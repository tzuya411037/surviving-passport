using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layer2 : MonoBehaviour
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
        if (animator.transform.localScale.y > 0.7F) { sprite.sortingOrder = 5; }
        else { sprite.sortingOrder = 3; }
    }
}
//< 0.5225 > 0.7