using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invisible : MonoBehaviour
{
    public SpriteRenderer wall;
    void OnTriggerExit2D(Collider2D coll)
    {
        wall.color = new Color32(255, 255, 255, 255);
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        wall.color = new Color32(255, 255, 255, 50);
    }
}