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
}
