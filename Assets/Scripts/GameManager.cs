using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    public bool gameStarted = false;

    public GameObject gameOverPanel;
    public GameObject gameStartText;
    public GameObject scoreBox;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endScore;
    Animator animator;
    public float points = 0;


    void Start(){
        animator = FindObjectOfType<PlayerMovement>().GetComponent<Animator>();
    }
    public void EndGame()
    {
        gameOver = true;
        animator.SetBool("isGameStarted", false);
        animator.SetBool("isGrounded", true);
        animator.SetTrigger("isGameOver");
        scoreBox.SetActive(false);
        endScore.text = "Score: " + points.ToString();
        gameOverPanel.SetActive(true);
    } 

    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Update(){
        if(Input.anyKey && !gameStarted){
            gameStarted = true;
            Destroy(gameStartText);
            scoreBox.SetActive(true);
            animator.SetBool("isGameStarted", true);
        }
        if(gameStarted){
            scoreText.text = points.ToString();
        }
    }
}
