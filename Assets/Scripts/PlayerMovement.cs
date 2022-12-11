using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private GameManager gameManager;
    private Animator animator;
    private AudioManager audioManager;
    public float speed = 17.0f;
    public float jumpForce = 15.0f;
    public float gravity = -20.0f;
    private int currentLane = 1;
    private float laneDistance = 2.5f;
    private Vector3 moveDirection;
    private Vector3 velocity;
    public float maxSpeed = 25f;
    public float speedIncrement = 0.05f;
    private bool isSliding = false;
    private bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
    private float groundDistance = 0.2f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if(gameManager.gameOver || !gameManager.gameStarted)
            return;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if(speed < maxSpeed){
            speed += speedIncrement * Time.deltaTime;
        }
        moveDirection.z = speed;
    
        if(isGrounded){
            animator.SetBool("isGrounded", true);
            if(velocity.y < 0){
                velocity.y = -2f;
            }
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)){
                Jump();
            }      
            if(!isSliding && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))){
                StartCoroutine(Slide());
            }
        }
        else{
            animator.SetBool("isGrounded", false);
            velocity.y += gravity * Time.deltaTime;
            if(!isSliding && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))){
                StartCoroutine(Slide());
            velocity.y = -jumpForce;
            }
        }

        controller.Move(velocity * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
            if(currentLane > 0){
                audioManager.PlaySound("strafe-sound");
                currentLane--;
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){
            if(currentLane < 2){
                audioManager.PlaySound("strafe-sound");
                currentLane++;
            }
        }
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if(currentLane == 0){
            targetPosition += Vector3.left * laneDistance;
        }
        else if(currentLane == 2){
            targetPosition += Vector3.right * laneDistance;
        }
        
        if(transform.position != targetPosition){
            Vector3 difference = targetPosition - transform.position;
            controller.Move(difference * 20 * Time.deltaTime);
        }
        controller.Move(moveDirection * Time.deltaTime);
    }

    private IEnumerator Slide(){
        audioManager.PlaySound("slide-sound");
        Sliding(true);
        yield return new WaitForSeconds(0.2f);
        ShrinkController();
        yield return new WaitForSeconds(0.8f);
        Sliding(false);
    }

    private void Sliding(bool sliding){
        if(sliding){
            isSliding = true;
            animator.SetBool("isSliding", true);
        }
        else{
            animator.SetBool("isSliding", false);
            ResetController();
            isSliding = false;
        }
    }

    private void Jump()
    {   
        audioManager.PlaySound("jump-sound");
        StopCoroutine(Slide());
        Sliding(false);
        velocity.y = jumpForce;
    }

    private void ShrinkController(){
        controller.center = new Vector3(0, 0.5f, 0);
        controller.height = 1;
    }

    private void ResetController(){
        controller.center = new Vector3(0, 1.0f, 0);
        controller.height = 2;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit){
        if (hit.transform.tag == "Obstacle"){
            audioManager.PlaySound("die-sound");
            audioManager.StopSound("soundtrack");
            gameManager.EndGame();
        }
    }

}
