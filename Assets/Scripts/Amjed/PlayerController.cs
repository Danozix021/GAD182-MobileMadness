using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed = 3f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    private float verticalVelocity;
    private bool isDead = false;

    private int chosenLane = 1; 
    public float laneDistance = 1.5f; 
    private float targetX;

    public float laneSwitchSpeed = 10f; 

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isDead) return;

        
        direction = Vector3.forward * forwardSpeed;

        
        if (Input.GetKeyDown(KeyCode.D))
        {
            chosenLane = Mathf.Min(chosenLane + 1, 2);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            chosenLane = Mathf.Max(chosenLane - 1, 0);
        }

        
        targetX = (chosenLane - 1) * laneDistance;
        float deltaX = targetX - transform.position.x;
        float moveX = deltaX * laneSwitchSpeed;
        direction.x = moveX;

        
        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f; 

            if (Input.GetKeyDown(KeyCode.W))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        direction.y = verticalVelocity;
    }
    void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
        if (isDead) return; 
        controller.Move(direction * Time.fixedDeltaTime);
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Wall") || hit.gameObject.CompareTag("Train"))
        {
            Debug.Log("Player hit obstacle — Game Over");

            isDead = true;
            Time.timeScale = 0;
            FindObjectOfType<UIManager>().GameOver();

        }
    }
         private void OnTriggerEnter(Collider other)
   {
        if (other.CompareTag("Finish"))
        {
            isDead = true;
            Time.timeScale = 0;
            FindObjectOfType<UIManager>().YouWin();
        }
    }
}
