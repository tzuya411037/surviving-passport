using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Fade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetMouseButtonDown(0)){
            GetComponent<Animation>().Play("FadeOut");  
       }
    }
    public void ChangeScene(int i){
     SceneManager.LoadScene(i);
   }
}