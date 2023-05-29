using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_goQuestion : MonoBehaviour
{
    void Start () {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }
    public void Click()
    {
        Debug.Log("Click");
        SceneManager.LoadScene("Question");
    }
}
