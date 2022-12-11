using UnityEngine;

public class StarManager : MonoBehaviour
{
    GameManager gameManager;
    AudioManager audioManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            audioManager.PlaySound("chime-sound");
            gameManager.points++;
            Destroy(gameObject);
        }
    }
}
