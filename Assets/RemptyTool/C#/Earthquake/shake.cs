using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class shake : MonoBehaviour
{
    public ImpulseTest cameraShake;
    GM4 gameManager;
    public SpriteRenderer Player;
    public Transform player;
    public AudioSource audio;
    public Vector3 offset;
    private float deltaTime;
    public Animator playerAni;
    public AudioClip corr;
    public AudioClip err;
    public GameObject count;
    public GameObject hide;
    public GameObject corrhide;
    public SpriteRenderer one;
    public SpriteRenderer two;
    public SpriteRenderer three;
    void Awake()
    {
        gameManager = FindObjectOfType<GM4>();
    }
    void Start() 
    { 
        audio = GetComponent<AudioSource>(); 
    }
    void Update()
    {
        deltaTime += Time.deltaTime;
        int ShakeTime = (int)deltaTime;
        if (gameManager.Shaked == 1)
        {
            gameManager.stop = 1;
            one.color = new Color32(255, 255, 255, 0);
            two.color = new Color32(255, 255, 255, 0);
            three.color = new Color32(255, 255, 255, 0);
            float x = Random.Range(-1f, 1f) * 0.4f;
            //float y = Random.Range(-1f, 1f) * magnitude;
            transform.position = new Vector3(player.position.x + x, player.position.y, -10f);
            if (ShakeTime > 12 && ShakeTime < 17) { gameManager.pushed = 0; gameManager.audio = 1; gameManager.Shaked = 0; gameManager.hide = 0; playerAni.SetInteger("Status", 2); Player.color = new Color32(255, 255, 255, 255); }
        }
        else
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position 
            if (ShakeTime == 15 && gameManager.audio == 1) { 
                if (gameManager.corr == 1) { gameManager.audio = 0; audio.PlayOneShot(corr, 0.7F); } 
                else { gameManager.audio = 0; audio.PlayOneShot(err, 0.7F); if (SceneManager.GetActiveScene().name == "Entrance") { gameManager.chance += 4; } else { gameManager.chance += 4; } } 
            }
            if (ShakeTime > 17) {gameManager.corr = 0;
                if (SceneManager.GetActiveScene().name != "Entrance")
                {
                    if (gameManager.rooms < 4)
                    {
                        gameManager.rooms++;
                        if (SceneManager.GetActiveScene().name == "room1") {SceneManager.LoadScene("room2"); gameManager.stop = 0; }
                        if (SceneManager.GetActiveScene().name == "room2") {SceneManager.LoadScene("room4"); gameManager.stop = 0; }
                        if (SceneManager.GetActiveScene().name == "room4") {SceneManager.LoadScene("room6"); gameManager.stop = 0; }
                        if (SceneManager.GetActiveScene().name == "room6") {SceneManager.LoadScene("kitchen"); gameManager.stop = 0; }
                        if (SceneManager.GetActiveScene().name == "kitchen") {SceneManager.LoadScene("room1"); gameManager.stop = 0; }
                    }
                    else {SceneManager.LoadScene("Entrance"); gameManager.stop = 0; }
                }
                else { count.SetActive(false); gameManager.stop = 0; gameManager.finished = 1; }
            }
        }
    }
}