using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daniel
{
    public class CameraMovement : MonoBehaviour
    {
        public Transform player;
        public float smoothSpeed;
        public float yDistance;

        private float cameraY;

        // Start is called before the first frame update
        void Start()
        {
            smoothSpeed = 7f;
            yDistance = 7f;
       
            player = GameObject.FindGameObjectWithTag("Player").transform;
            if (player == null)
            {
                Debug.Log("NO Player Found!!");
                return;
            }


            cameraY = transform.position.y;
        
        }

        private void LateUpdate() // used LateUpdate because i want it to run after the player haas moved udwards and not while the player is moving.
        {
            float targetY = player.position.y + yDistance;


            if (targetY > cameraY)
            {
                cameraY = targetY;

                Vector3 newPos = new Vector3 (transform.position.x, targetY, transform.position.z); // Only moves the camera in the y postion and keeps the x and z the same.
                transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed * Time.deltaTime);// smoothly moves the camera to new position.
            }   
        }
    }

}
