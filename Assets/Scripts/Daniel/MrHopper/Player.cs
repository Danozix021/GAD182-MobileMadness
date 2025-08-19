using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Daniel
{ 
    public class Player : MonoBehaviour
    {

        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;

        [SerializeField] private BoxCollider bc;
        [SerializeField] private ParticleSystem deathEffect;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private MeshRenderer MeshRenderer;
        // Start is called before the first frame update
        void Start()
        {
            moveSpeed = 5f;
            jumpForce = 10f;

            rb = GetComponent<Rigidbody>();
            deathEffect = GetComponent<ParticleSystem>();
            bc = GetComponent<BoxCollider>();
            MeshRenderer = GetComponent<MeshRenderer>();
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

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.CompareTag("Platform"))
            {
                if (rb.velocity.y <= 0f)
                {
                    Vector3 velocity = rb.velocity;
                    velocity.y = jumpForce;
                    rb.velocity = velocity;
                }

            }

            if (collider.gameObject.CompareTag("Death"))
            {
                    Debug.Log("you DIed");
                    deathEffect.Play();
                    bc.enabled = false;
                    MeshRenderer.enabled = false;
            }

            if (collider.gameObject.CompareTag("finish"))
            {
                Debug.Log("You Win!!!!");
            }

        }


    }
}
