using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    GameObject player;
    PlayerMovement playerMovement;
    public float cameraDistance = 3f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = FindObjectOfType<PlayerMovement>();
        cameraDistance = player.transform.position.z - transform.position.z;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - cameraDistance);
    }
}
