using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour
{
    public bool playerIn = false;
    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Player")
            playerIn = true;
    }
    void OnTriggerExit2D(Collider2D col) 
    {
        if (col.gameObject.tag == "Player")
            playerIn = false;
    }
}
