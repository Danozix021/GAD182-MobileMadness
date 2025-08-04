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

    private int chosenLane = 1; // 0 = left, 1 = middle, 2 = right
    public float laneDistance = 1.5f; // adjust this to fit your track
    private float targetX;

    public float laneSwitchSpeed = 10f; // how fast to lerp between lanes

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isDead) return;

        // Forward movement
        direction = Vector3.forward * forwardSpeed;

        // Lane switching input
        if (Input.GetKeyDown(KeyCode.D))
        {
            chosenLane = Mathf.Min(chosenLane + 1, 2);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            chosenLane = Mathf.Max(chosenLane - 1, 0);
        }

        // Calculate X position for lane switching
        targetX = (chosenLane - 1) * laneDistance;
        float deltaX = targetX - transform.position.x;
        float moveX = deltaX * laneSwitchSpeed;
        direction.x = moveX;

        // Ground check & jumping
        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f; // Small negative to stay grounded

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
        if (isDead) return; // Don’t move if dead
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
            FindObjectOfType<UIManager>().YouWin(); // Call the win screen
        }
    }
}
