using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daniel
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("you DIed");
            }
        }
    }

}
