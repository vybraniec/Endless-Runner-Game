using UnityEngine;

public class Star : MonoBehaviour
{
    GameManager gameManager;
    AudioManager audioManager;
    StarManager starManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
        starManager = FindObjectOfType<StarManager>();
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            starManager.StarSound(Time.time);
            audioManager.PlaySound("chime-sound");
            gameManager.points++;
            Destroy(gameObject);
        }
    }
}
