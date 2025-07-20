using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Daniel
{
    public class TempPlatform : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}
