using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [SerializeField] private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5f;
        jumpForce = 10f;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;
        }

        transform.Translate(Vector3.right * moveInput * moveSpeed * Time.deltaTime);
    

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            if (rb.velocity.y <= 0f)
            {
                Vector3 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }

        }
    }
}
