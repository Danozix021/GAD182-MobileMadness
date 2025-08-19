using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daniel
{
    public class BallMovement : MonoBehaviour
    {

        [SerializeField] float speed;
        [SerializeField] Rigidbody rb;
        [SerializeField] Stopwatch sw;
        // Start is called before the first frame update
        void Start()
        {
            speed = 4.5f;

            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            Vector3 direction = new Vector3(h, 0f, v).normalized;

            Vector3 move = direction * speed * Time.fixedDeltaTime;

            rb.MovePosition(rb.position +  move);
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.CompareTag("Death"))
            {
                Debug.Log("You Died");
                Destroy(this.gameObject);
                sw.StopStopwatch();
            }

            if (collider.gameObject.CompareTag("finish"))
            {
                Debug.Log("You Win!!!");
                sw.StopStopwatch();
            }
        }

       
    }

}
