using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    void Start(){
        FindObjectOfType<AudioManager>().PlaySound("soundtrack");
    }
    
    public void StartGame(){
        SceneManager.LoadScene("MainScene");
    }

    void Update(){
        Vector2 resTarget = new Vector2(1080f, 1920f);
        Vector2 resViewport = new Vector2( Screen.width, Screen.height );
        Vector2 resNormalized = resTarget / resViewport; // target res in viewport space
        Vector2 size = resNormalized / Mathf.Max( resNormalized.x, resNormalized.y );
        Camera.main.rect = new Rect( default, size ) { center = new Vector2( 0.5f, 0.5f ) };
    }
}
