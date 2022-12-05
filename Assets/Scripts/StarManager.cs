using UnityEngine;

public class StarManager : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            gameManager.points++;
            Destroy(gameObject);
        }
    }
}
